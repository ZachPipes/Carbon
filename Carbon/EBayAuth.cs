using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;

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
            var jsonData = JsonConvert.DeserializeObject<TempAuth>(json);
            if (jsonData == null) return null;
            return new EBayAuth(jsonData.authType, jsonData.ClientId, jsonData.ClientSecret, jsonData.RedirectUri, jsonData.Scopes);
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

        private class TempAuth {
            public string authType { get; set; }
            public string ClientId { get; set; }
            public string ClientSecret { get; set; }
            public string RedirectUri { get; set; }
            public string Scopes { get; set; }
        }
    }
}