using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace Carbon;

// AppState used for token manipulation, testing and file paths
public sealed class AppState {
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
                RefreshToken = root.GetProperty(nameof(RefreshToken)).GetString() ?? "";
                RefreshTokenExpiration = root.GetProperty(nameof(RefreshTokenExpiration)).GetInt32();
            } catch (Exception ex) {
                Console.WriteLine($"Failed to parse Token.json: {ex.Message}");
                SetDefaultTokens();
            }
        }
        else {
            SetDefaultTokens();
        }

        IsSandboxMode = true;
    }

    private void SetDefaultTokens() {
        AccessToken = "";
        AccessTokenExpiration = 0;
        RefreshToken = "";
        RefreshTokenExpiration = 0;
    }

    public async Task CheckForTokenUpdate() {
        int currentTime = Utils.GetCurrentTimeInSeconds();

        if (currentTime > AccessTokenExpiration || AccessToken == "") {

            string api = Instance.IsSandboxMode ? ".sandbox" : "";

            string endpoint = $"https://api{api}.ebay.com/identity/v1/oauth2/token";

            using HttpClient client = new();

            string credentials = $"{AuthenticationState.Instance.ClientId}:{AuthenticationState.Instance.ClientSecret}";

            string base64Credentials = Convert.ToBase64String(Encoding.UTF8.GetBytes(credentials));

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", base64Credentials);

            FormUrlEncodedContent content = new([
                new KeyValuePair<string,string>("grant_type", "refresh_token"),
                new KeyValuePair<string,string>("refresh_token", Instance.RefreshToken),
                new KeyValuePair<string,string>("scope", AuthenticationState.Instance.Scopes ?? "")
            ]);

            HttpResponseMessage response = await client.PostAsync(endpoint, content);

            string responseContent = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode) {
                JsonDocument jsonDoc = JsonDocument.Parse(responseContent);

                if (jsonDoc.RootElement.TryGetProperty("access_token", out var tokenElement)) {
                    Instance.AccessToken = tokenElement.GetString() ?? "";
                    return;
                }

                throw new Exception($"Access token not found in response.");
            }

            throw new Exception($"Failed to refresh token: {response.StatusCode} - {responseContent}");
        }
    }

    public string AccessToken { get; set; }
    public int AccessTokenExpiration { get; set; }
    public string RefreshToken { get; set; }
    public int RefreshTokenExpiration { get; set; }
    public bool IsSandboxMode { get; set; }
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
                Utils.ShowError($"Invalid credentials: Missing {jsonDataType}.");
            }
        }
    }

    // Executes front-end authentication
    public static void LaunchAuthFlow() {
        // Launch the default browser with the url
        try {
            string api = AppState.Instance.IsSandboxMode ? ".sandbox" : "";
            string url = $"https://auth{api}.ebay.com/oauth2/authorize?client_id={Instance.ClientId}&redirect_uri={Instance.RedirectUri}&response_type=code&scope={Instance.Scopes}";

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
        Uri uri = new Uri(redirectUrl);
        NameValueCollection queryParams = System.Web.HttpUtility.ParseQueryString(uri.Query);
        string code = queryParams["code"];

        if (string.IsNullOrEmpty(code)) {
            Utils.ShowError($"Code not found in url.");
            return;
        }

        string response = await CodeForTokenExchange(code);
        using JsonDocument doc = JsonDocument.Parse(response);
        JsonElement root = doc.RootElement;

        AppState.Instance.AccessToken = root.GetProperty("access_token").GetString()   ?? "EMPTY ACCESS TOKEN";
        AppState.Instance.RefreshToken = root.GetProperty("refresh_token").GetString() ?? "EMPTY REFRESH TOKEN";

        // Converting times
        Dictionary<string,object> jsonData = new() {
            ["AccessTokenExpiration"] = Utils.GetCurrentTimeInSeconds() + root.GetProperty("expires_in").GetInt32(),
            ["RefreshToken"] = root.GetProperty("refresh_token").GetString() ?? "EMPTY REFRESH TOKEN",
            ["RefreshTokenExpiration"] = Utils.GetCurrentTimeInSeconds() + root.GetProperty("refresh_token_expires_in").GetInt32(),
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

        string credentials = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{ClientId}:{ClientSecret}"));
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);

        FormUrlEncodedContent requestBody = new FormUrlEncodedContent([
            new KeyValuePair<string, string>("grant_type", "authorization_code"),
            new KeyValuePair<string, string>("code", code),
            new KeyValuePair<string, string>("redirect_uri", RedirectUri ?? "EMPTY REDIRECTURI")
        ]);

        string api = AppState.Instance.IsSandboxMode ? ".sandbox" : "";
        HttpResponseMessage response = await client.PostAsync($"https://api{api}.ebay.com/identity/v1/oauth2/token", requestBody);

        return response.Content.ReadAsStringAsync().Result;
    }

    public string? ClientId { get; set; }
    public string? ClientSecret { get; set; }
    public string? RedirectUri { get; set; }
    public string? Scopes { get; set; }
}