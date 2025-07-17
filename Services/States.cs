using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Data.Sqlite;

namespace Carbon.Services;

// AppState used for token manipulation, testing and file paths
public class AppState {
    private static readonly Lazy<AppState> _instance = new(() => new AppState());
    public static AppState Instance => _instance.Value;

    private const string AppFolderName = "Carbon";
    private const string TokenFileName = "Token.json";

    private AppState() {
        FilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), AppFolderName);

        string tokenFilePath = Path.Combine(FilePath, TokenFileName);

        if (File.Exists(tokenFilePath)) {
            try {
                using JsonDocument doc = JsonDocument.Parse(File.ReadAllText(tokenFilePath));
                JsonElement root = doc.RootElement;

                AccessToken = "";
                AccessTokenExpiration = root.GetProperty(nameof(AccessTokenExpiration)).GetInt32();
                RefreshToken = root.GetProperty(nameof(RefreshToken)).GetString();
                RefreshTokenExpiration = root.GetProperty(nameof(RefreshTokenExpiration)).GetInt32();
            } catch (Exception ex) {
                Console.WriteLine($"Failed to parse Token.json: {ex.Message}");
                SetDefaultTokens();
            }
        }
        else {
            SetDefaultTokens();
        }

        // Out of sandbox mode
        API = "";
    }

    private void SetDefaultTokens() {
        AccessToken = "";
        AccessTokenExpiration = 0;
        RefreshToken = "";
        RefreshTokenExpiration = 0;
    }

    public async Task CheckForTokenUpdate() {
        int currentTime = Utilities.GetCurrentTimeInSeconds();

        if (currentTime > AccessTokenExpiration || AccessToken == "") {
            
            string endpoint = $"https://api.{API}ebay.com/identity/v1/oauth2/token";

            using HttpClient client = new();

            string credentials = $"{AuthenticationState.Instance.ClientId}:{AuthenticationState.Instance.ClientSecret}";

            string base64Credentials = Convert.ToBase64String(Encoding.UTF8.GetBytes(credentials));

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", base64Credentials);

            FormUrlEncodedContent content = new([
                new KeyValuePair<string,string>("grant_type", "refresh_token"),
                new KeyValuePair<string,string>("refresh_token", Instance.RefreshToken),
                new KeyValuePair<string,string>("scope", AuthenticationState.Instance.Scopes)
            ]);

            HttpResponseMessage response = await client.PostAsync(endpoint, content);

            string responseContent = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode) {
                JsonDocument jsonDoc = JsonDocument.Parse(responseContent);

                if (jsonDoc.RootElement.TryGetProperty("access_token", out var tokenElement)) {
                    Instance.AccessToken = tokenElement.GetString();
                    return;
                }

                throw new Exception($"Access token not found in response.");
            }

            throw new Exception($"Failed to refresh token: {response.StatusCode} - {responseContent}");
        }
    }

    public string? AccessToken { get; set; }
    public int AccessTokenExpiration { get; set; }
    public string? RefreshToken { get; set; }
    public int RefreshTokenExpiration { get; set; }
    public string API { get; set; }
    public string FilePath { get; set; }
}

public class AuthenticationState {
    private static readonly Lazy<AuthenticationState> _instance = new(() => new AuthenticationState());
    public static AuthenticationState Instance => _instance.Value;

    private const string CredentialsFileName = "ProgramCredentials.json";
    private const string TokenFileName = "Token.json";

    private AuthenticationState() {
        string credentialsFilePath = Path.Combine(AppState.Instance.FilePath, CredentialsFileName);
        using JsonDocument doc = JsonDocument.Parse(File.ReadAllText(credentialsFilePath));
        JsonElement root = doc.RootElement;

        ClientId = root.GetProperty(nameof(ClientId)).GetString();
        ClientSecret = root.GetProperty(nameof(ClientSecret)).GetString();
        RedirectUri = root.GetProperty(nameof(RedirectUri)).GetString();
        Scopes = root.GetProperty(nameof(Scopes)).GetString();

        string[] jsonDataTypes = ["ClientId", "ClientSecret", "RedirectUri", "Scopes"];
        foreach (string jsonDataType in jsonDataTypes) {
            if (string.IsNullOrEmpty(jsonDataType)) {
                Console.WriteLine($"Invalid credentials: Missing {jsonDataType}.");
            }
        }
    }

    // Executes front-end authentication
    public static void LaunchAuthFlow() {
        // Launch the default browser with the url
        try {
            string url = $"https://auth.{AppState.Instance.API}ebay.com/oauth2/authorize?client_id={Instance.ClientId}&redirect_uri={Instance.RedirectUri}&response_type=code&scope={Instance.Scopes}";

            Process.Start(new ProcessStartInfo {
                FileName = url,
                UseShellExecute = true
            });
        } catch (Exception ex) {
            Console.WriteLine("Error launching auth browser: " + ex.Message);
        }
    }

    // Executes back-end authentication
    public async Task ExecuteEbayAuth() {
        // Receive the url
        string redirectUrl = Microsoft.VisualBasic.Interaction.InputBox("Sign in to your eBay account.\nThen paste the URL here:", "Enter URL");

        // Parse for the code
        Uri uri = new(redirectUrl);
        NameValueCollection parsedQuery = HttpUtility.ParseQueryString(uri.Query);

        string code = parsedQuery["code"];

        if (string.IsNullOrEmpty(code)) {
            Console.WriteLine("Code is missing");
        }

        string response = await CodeForTokenExchange(code);
        using JsonDocument doc = JsonDocument.Parse(response);
        JsonElement root = doc.RootElement;

        AppState.Instance.AccessToken = root.GetProperty("access_token").GetString()   ?? "EMPTY ACCESS TOKEN";
        AppState.Instance.RefreshToken = root.GetProperty("refresh_token").GetString() ?? "EMPTY REFRESH TOKEN";

        // Converting times
        Dictionary<string,object> jsonData = new() {
            ["AccessTokenExpiration"] = Utilities.GetCurrentTimeInSeconds() + root.GetProperty("expires_in").GetInt32(),
            ["RefreshToken"] = root.GetProperty("refresh_token").GetString() ?? "EMPTY REFRESH TOKEN",
            ["RefreshTokenExpiration"] = Utilities.GetCurrentTimeInSeconds() + root.GetProperty("refresh_token_expires_in").GetInt32(),
        };

        JsonSerializerOptions options = new() {
            WriteIndented = true
        };
        string json = JsonSerializer.Serialize(jsonData, options);
        string tokenFilePath = Path.Combine(AppState.Instance.FilePath, TokenFileName);
        await File.WriteAllTextAsync(tokenFilePath, json);

        Microsoft.VisualBasic.Interaction.MsgBox("EBay Authorization Complete!");
    }

    private async Task<string> CodeForTokenExchange(string code) {
        using HttpClient client = new();
        
        // Outgoing information
        string credentials = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{ClientId}:{ClientSecret}"));
        
        // Building request
        HttpRequestMessage request = new(HttpMethod.Post, "https://api.ebay.com/identity/v1/oauth2/token");
        request.Headers.Authorization = new AuthenticationHeaderValue("Basic", credentials);
        request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        // Building payload
        StringBuilder payload = new();
        payload.Append("grant_type=authorization_code");
        payload.Append("&code=" + Uri.EscapeDataString(code));
        if (String.IsNullOrEmpty(Instance.RedirectUri)) {
            Console.WriteLine("RedirectUri is missing");
            return "REDIRECT URI is missing";
        }
        payload.Append("&redirect_uri=" + Uri.EscapeDataString(Instance.RedirectUri));

        request.Content = new StringContent(payload.ToString(), Encoding.UTF8, "application/x-www-form-urlencoded");

        // Send payload
        HttpResponseMessage response = await client.SendAsync(request);
        string responseContent = await response.Content.ReadAsStringAsync();
        
        return responseContent;
    }

    public string? ClientId { get; set; }
    public string? ClientSecret { get; set; }
    public string? RedirectUri { get; set; }
    public string? Scopes { get; set; }
}

public sealed class DatabaseState {
    private static readonly Lazy<DatabaseState> _instance = new(() => new DatabaseState());
    private SqliteConnection _connection;

    private DatabaseState() {
        const string connectionString = "Data source=carbon.db";
        _connection = new SqliteConnection(connectionString);
        _connection.Open();
        
        string[] tables = new string[3];
        tables[0] = @"
                      CREATE TABLE IF NOT EXISTS InventoryPages (
                          sku TEXT NOT NULL
                      )";
        tables[1] = @"
                      CREATE TABLE IF NOT EXISTS Listings (
                          sku TEXT NOT NULL
                      )";
        tables[2] = @"
                      CREATE TABLE IF NOT EXISTS Orders (
                          sku TEXT NOT NULL
                      )";
        
        foreach (string table in tables) {
            using SqliteCommand cmd = new(table, _connection);
            cmd.ExecuteNonQuery();
        }
    }
    
    public static DatabaseState Instance => _instance.Value;
}
