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

    private AppState() {
        FilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), AppFolderName);

        // Reading stored json
        using var doc = JsonDocument.Parse(File.ReadAllText(FilePath));
        var root = doc.RootElement;

        AccessToken = root.GetProperty(nameof(AccessToken)).GetString() ?? "";
        AccessTokenExpiration = root.GetProperty(nameof(AccessTokenExpiration)).GetInt32();
        RefreshToken = root.GetProperty(nameof(RefreshToken)).GetString() ?? "";
        RefreshTokenExpiration = root.GetProperty(nameof(RefreshTokenExpiration)).GetInt32();
        IsSandboxMode = true;
    }

    public async Task CheckForTokenUpdate() {
        var currentTime = Utils.GetCurrentTimeInSeconds();
        
        if (currentTime > AccessTokenExpiration) {
            var api = Instance.IsSandboxMode ? ".sandbox" : "";
            var endpoint = $"https://api{api}.ebay.com/identity/v1/oauth2/token";
            using var client = new HttpClient();

            var credentials = $"{AuthenticationState.Instance.ClientId}:{AuthenticationState.Instance.ClientSecret}";
            var base64Credentials = Convert.ToBase64String(Encoding.UTF8.GetBytes(credentials));

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", base64Credentials);

            var content = new FormUrlEncodedContent([
                new("grant_type", "refresh_token"),
                new("refresh_token", Instance.RefreshToken),
                new("scope", AuthenticationState.Instance.Scopes ?? "")
            ]);

            var response = await client.PostAsync(endpoint, content);
            var responseContent = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode) {
                var jsonDoc = JsonDocument.Parse(responseContent);
                if (jsonDoc.RootElement.TryGetProperty("access_token", out var tokenElement)) {
                    Instance.AccessToken = tokenElement.GetString() ?? "";
                }

                throw new Exception("Access token not found in response.");
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
        var credentialsFilePath = Path.Combine(AppState.Instance.FilePath, CredentialsFileName);
        using var doc = JsonDocument.Parse(File.ReadAllText(credentialsFilePath));
        var root = doc.RootElement;

        ClientId = root.GetProperty(nameof(ClientId)).GetString();
        ClientSecret = root.GetProperty(nameof(ClientSecret)).GetString();
        RedirectUri = root.GetProperty(nameof(RedirectUri)).GetString();
        Scopes = root.GetProperty(nameof(Scopes)).GetString();

        string[] jsonDataTypes = ["ClientId", "ClientSecret", "RedirectUri", "Scopes"];
        foreach (var jsonDataType in jsonDataTypes) {
            if (string.IsNullOrEmpty(jsonDataType)) {
                Utils.ShowError($"Invalid credentials: Missing {jsonDataType}.");
            }
        }
    }

    // Executes front-end authentication
    public static void LaunchAuthFlow() {
        // Launch the default browser with the url
        try {
            var api = AppState.Instance.IsSandboxMode ? ".sandbox" : "";
            var url = $"https://auth{api}.ebay.com/oauth2/authorize?client_id={Instance.ClientId}&redirect_uri={Instance.RedirectUri}&response_type=code&scope={Instance.Scopes}";

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
        var redirectUrl = Microsoft.VisualBasic.Interaction.InputBox("Sign in to your eBay account.\nThen paste the URL here:", "Enter URL");

        // Parse for the code
        var uri = new Uri(redirectUrl);
        var queryParams = System.Web.HttpUtility.ParseQueryString(uri.Query);
        var code = queryParams["code"];

        if (string.IsNullOrEmpty(code)) {
            Utils.ShowError($"Code not found in url.");
            return;
        }

        var response = await CodeForTokenExchange(code);
        using JsonDocument doc = JsonDocument.Parse(response);
        var root = doc.RootElement;

        AppState.Instance.AccessToken = root.GetProperty("access_token").GetString() ?? "EMPTY ACCESS TOKEN";
        AppState.Instance.RefreshToken = root.GetProperty("refresh_token").GetString() ?? "EMPTY REFRESH TOKEN";

        // Converting times
        var jsonData = new Dictionary<string, object> {
            ["AccessTokenExpiration"] = Utils.GetCurrentTimeInSeconds() + root.GetProperty("expires_in").GetInt32(),
            ["RefreshToken"] = root.GetProperty("refresh_token").GetString() ?? "EMPTY REFRESH TOKEN",
            ["RefreshTokenExpiration"] = Utils.GetCurrentTimeInSeconds() + root.GetProperty("refresh_token_expires_in").GetInt32(),
        };

        var options = new JsonSerializerOptions {
            WriteIndented = true
        };
        var json = JsonSerializer.Serialize(jsonData, options);
        var tokenFilePath = Path.Combine(AppState.Instance.FilePath, TokenFileName);
        await File.WriteAllTextAsync(tokenFilePath, json);

        Microsoft.VisualBasic.Interaction.MsgBox("EBay Authorization Complete!");
    }

    private async Task<string> CodeForTokenExchange(string code) {
        using var client = new HttpClient();

        var credentials = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{ClientId}:{ClientSecret}"));
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);

        var requestBody = new FormUrlEncodedContent([
            new("grant_type", "authorization_code"),
            new("code", code),
            new("redirect_uri", RedirectUri ?? "EMPTY REDIRECTURI")
        ]);

        var api = AppState.Instance.IsSandboxMode ? ".sandbox" : "";
        var response = await client.PostAsync($"https://api{api}.ebay.com/identity/v1/oauth2/token", requestBody);

        return response.Content.ReadAsStringAsync().Result;
    }

    public string? ClientId { get; set; }
    public string? ClientSecret { get; set; }
    public string? RedirectUri { get; set; }
    public string? Scopes { get; set; }
}