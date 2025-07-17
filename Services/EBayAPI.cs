using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Carbon.Services;


public class EBayAPI {
    private static readonly HttpClient HttpClient = new();

    public static async Task<String> generateInventoryItem(string payload) {
        // SKU
        string sku = $"UNQ-{DateTime.UtcNow:yyyyMMdd}-{Guid.NewGuid().ToString().Substring(0, 8)}";
        Console.WriteLine($"\ngenerateInventoryItem(sku): <<< {sku} >>>");

        // URL
        string url = $"https://api.{AppState.Instance.API}ebay.com/sell/inventory/v1/inventory_item/{sku}";
        Console.WriteLine($"generateInventoryItem(url): <<< {url} >>>");

        // Request
        HttpRequestMessage request = new(HttpMethod.Put, url) {
            Content = new StringContent(payload, Encoding.UTF8, "application/json")
        };
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", AppState.Instance.AccessToken);
        request.Content.Headers.ContentLanguage.Add("en-US");

        // Response
        HttpResponseMessage response = await HttpClient.SendAsync(request);

        // Console Output
        Console.WriteLine($"generateInventoryItem(response.StatusCode): <<< {response.StatusCode} >>>");
        Console.WriteLine($"generateInventoryItem(response.RequestMessage): <<< {response.ReasonPhrase} >>>");
        if(!response.IsSuccessStatusCode) {
            string errorContent = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"generateInventoryItem(ERROR): <<< {errorContent} >>>");
        }

        return sku;
    }

    private static async Task<String> getPolicyID(string policyName) {
        Console.WriteLine($"\ngetPolicyID(): <<< {policyName} >>>");
        string url;
        switch(policyName) {
            case "fulfillment":
                url = $"https://api.{AppState.Instance.API}ebay.com/sell/account/v1/fulfillment_policy?marketplace_id=EBAY_US";
                break;
            case "payment":
                url = $"https://api.{AppState.Instance.API}ebay.com/sell/account/v1/payment_policy?marketplace_id=EBAY_US";
                break;
            case "return":
                url = $"https://api.{AppState.Instance.API}ebay.com/sell/account/v1/return_policy?marketplace_id=EBAY_US";
                break;
            default:
                Console.WriteLine("getPolicyID(url): Invalid Input\n\t- Valid inputs are \"fulfillment\", \"payment\", \"return\"");
                return "";
        }

        Console.WriteLine($"getPolicyID(url): For [{policyName}] <<< {url} >>>");

        // Setting headers
        HttpClient.DefaultRequestHeaders.Clear();
        HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AppState.Instance.AccessToken);
        HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        HttpClient.DefaultRequestHeaders.Add("X-EBAY-C-MARKETPLACE-ID", "EBAY_US");

        // Getting json response
        HttpResponseMessage response = await HttpClient.GetAsync(url);
        string json = await response.Content.ReadAsStringAsync();

        // 
        JsonDocument doc = JsonDocument.Parse(json);

        string policyID = "";
        if(doc.RootElement.TryGetProperty($"{policyName}Policies", out JsonElement Policies)) {
            foreach(JsonElement policy in Policies.EnumerateArray()) {
                if(policy.TryGetProperty($"{policyName}PolicyId", out JsonElement PolicyID)) {
                    policyID = PolicyID.GetString();
                }
            }
        }

        Console.WriteLine($"getPolicyID(policyID): For {policyName} <<< {policyID} >>>");

        return policyID;
    }

    public static async Task<String> uploadImage(string filePath) {
        string url = "https://apim.ebay.com/commerce/media/v1_beta/image/create_image_from_file";
        using MultipartFormDataContent form = new();

        await using FileStream fileStream = File.OpenRead(filePath);
        
        StreamContent fileContent = new(fileStream);
        fileContent.Headers.ContentType = new MediaTypeHeaderValue("multipart/form-data");

        form.Add(fileContent, "image", Path.GetFileName(filePath));
        HttpClient.DefaultRequestHeaders.Clear();
        HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AppState.Instance.AccessToken);

        HttpResponseMessage response = await HttpClient.PostAsync("https://apim.ebay.com/commerce/media/v1_beta/image/create_image_from_file", form);
        string responseBody = await response.Content.ReadAsStringAsync();

        if(response.IsSuccessStatusCode) {
            string locationHeader = response.Headers.Location?.ToString() ?? "No location returned.";
            Console.WriteLine("Image uploaded successfully.");
            Console.WriteLine("Image location: " + locationHeader);
            Console.WriteLine("Response body: "  + responseBody);
        } else {
            Console.WriteLine("Upload failed with status: " + response.StatusCode);
            string errorBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine("Error response: " + errorBody);
        }

        return responseBody;
    }
}