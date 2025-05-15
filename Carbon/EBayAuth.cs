using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace Carbon {
    public class EBayAuth {
        private readonly string _authType;
        private readonly string _clientId;
        private readonly string _clientSecret;
        private readonly string _redirectUri;
        private readonly string _scopes;

        private EBayAuth(string authType, string clientId, string clientSecret, string redirectUri, string scopes) {
            _authType = authType;
            _clientId = clientId;
            _clientSecret = clientSecret;
            _redirectUri = redirectUri;
            _scopes = scopes;
        }

        public static EBayAuth FromJson(string json) {
            var jsonData = JsonSerializer.Deserialize<TempAuth>(json);
            if (jsonData == null) return null;
            return new EBayAuth(jsonData.AuthType, jsonData.ClientId, jsonData.ClientSecret, jsonData.RedirectUri, jsonData.Scopes);
        }

        public void LaunchAuthFlow() {
            try {
                string url = $"https://{_authType}.ebay.com/oauth2/authorize?" + $"client_id={_clientId}" + $"&redirect_uri={_redirectUri}" + $"&response_type=code" + $"&scope={_scopes}";
                Process.Start(new ProcessStartInfo { FileName = url, UseShellExecute = true });
            }
            catch (Exception ex) {
                Console.WriteLine("Error launching auth browser: " + ex.Message);
            }
        }

        public async Task<string> ExchangeCodeForTokenAsync(string code) {
            using var client = new HttpClient();

            string credentials = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{_clientId}:{_clientSecret}"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);

            var requestBody = new FormUrlEncodedContent(new[] {
                new KeyValuePair<string, string>("grant_type", "authorization_code"),
                new KeyValuePair<string, string>("code", code),
                new KeyValuePair<string, string>("redirect_uri", _redirectUri)
            });

            var response = await client.PostAsync("https://api.sandbox.ebay.com/identity/v1/oauth2/token", requestBody);

            return response.Content.ReadAsStringAsync().Result;
        }

        public async Task ExecuteEBayAuth() {
            LaunchAuthFlow();

            var redirectUrl = Microsoft.VisualBasic.Interaction.InputBox("Sign into your eBay account.\nThen paste the URL here:", "Enter URL");

            var uri = new Uri(redirectUrl);
            var queryParams = System.Web.HttpUtility.ParseQueryString(uri.Query);
            var code = queryParams["code"];

            // Get response
            var tokenResponse = await ExchangeCodeForTokenAsync(code);
            Console.WriteLine(tokenResponse);
            TokenResponse tokenData = JsonSerializer.Deserialize<TokenResponse>(tokenResponse);

            // Translate time in access_token_expires_in to an actual time value
            var currentTime = DateTime.Now;
            var expirationTime = currentTime.AddSeconds(tokenData.expires_in);
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            tokenData.expires_in = (int)(expirationTime - epoch).TotalSeconds;
            
            var options = new JsonSerializerOptions {
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                WriteIndented = true
            };

            // Write json
            File.WriteAllText($@"C:\Users\{Environment.UserName}\Documents\Carbon\token.json", JsonSerializer.Serialize(tokenData, options));

            Microsoft.VisualBasic.Interaction.MsgBox("EBay Authorization Complete!");
        }

        public static string GetAccessToken() {
            //TODO: Make a static path variable for entire program
            string jsonString = File.ReadAllText($@"C:\Users\{Environment.UserName}\Documents\Carbon\token.json");
            TokenResponse tokenResponse = JsonSerializer.Deserialize<TokenResponse>(jsonString);
            return tokenResponse.access_token;
        }

        //TODO: Create method to run on each launch of program to check for a valid access_token and update if need be

        private class TokenResponse {
            public string access_token { get; set; }
            public int expires_in { get; set; }
            public string refresh_token { get; set; }
            public int refresh_token_expires_in { get; set; }
            public string token_type { get; set; }
        }

        private class TempAuth {
            public string AuthType { get; set; }
            public string ClientId { get; set; }
            public string ClientSecret { get; set; }
            public string RedirectUri { get; set; }
            public string Scopes { get; set; }
        }
    }
}