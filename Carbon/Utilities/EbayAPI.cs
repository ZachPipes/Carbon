using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Carbon;

public static class EbayAPI {
    private static readonly HttpClient httpClient = new();

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
        HttpResponseMessage response = await httpClient.SendAsync(request);

        // Console Output
        Console.WriteLine($"generateInventoryItem(response.StatusCode): <<< {response.StatusCode} >>>");
        Console.WriteLine($"generateInventoryItem(response.RequestMessage): <<< {response.ReasonPhrase} >>>");
        if(!response.IsSuccessStatusCode) {
            string errorContent = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"generateInventoryItem(ERROR): <<< {errorContent} >>>");
        }

        return sku;
    }

    //TODO: Not important right now but make a function that can indent the console output of functions
    public static async Task<String> createOffer(string sku) {
        Console.WriteLine($"\ncreateOffer(sku): <<< {sku} >>>");

        string url = $"https://api.{AppState.Instance.API}ebay.com/sell/inventory/v1/offer";
        var offer = new {
            sku,
            marketplaceId = "EBAY_US",
            format = "FIXED_PRICE",
            availableQuantity = 1,
            categoryId = 30120,
            listingDescription = "Lumia phone with a stunning 5.7 inch Quad HD display and a powerful octa-core processor.",
            listingPolicies = new {
                fulfillmentPolicyId = await getPolicyID("fulfillment"),
                paymentPolicyId = await getPolicyID("payment"),
                returnPolicyId = await getPolicyID("return")
            },
            pricingSummary = new {
                price = new {
                    currency = "USD",
                    value = 1099.99
                }
            },
            merchantLocationKey = "us_mo",
        };

        string json = JsonSerializer.Serialize(offer);

        httpClient.DefaultRequestHeaders.Clear();
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AppState.Instance.AccessToken);
        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        StringContent content = new(json, Encoding.UTF8, "application/json");
        content.Headers.ContentLanguage.Add("en-US");

        HttpResponseMessage response = await httpClient.PostAsync(url, content);
        string result = await response.Content.ReadAsStringAsync();

        Console.WriteLine($"createOffer(result): {result}");

        string responseContent = await response.Content.ReadAsStringAsync();
        using JsonDocument doc = JsonDocument.Parse(responseContent);
        string offerId = doc.RootElement.GetProperty("offerId").GetString();

        return offerId;
    }

    public static async Task<String> publishOffer(string offerID) {
        string url = $"https://api.{AppState.Instance.API}ebay.com/sell/inventory/v1/offer/{offerID}/publish";
        Console.WriteLine($"publishOffer(url): For [{offerID}] <<< {url} >>>");

        httpClient.DefaultRequestHeaders.Clear();
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AppState.Instance.AccessToken);
        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        HttpResponseMessage response = await httpClient.PostAsync(url, new StringContent("", Encoding.UTF8, "application/json"));
        string result = await response.Content.ReadAsStringAsync();

        Console.WriteLine(result);

        return null;
    }
    //TODO: Allow for user to use different policies
    //      This would include creating setPolicy functions, etc
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
        httpClient.DefaultRequestHeaders.Clear();
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AppState.Instance.AccessToken);
        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        httpClient.DefaultRequestHeaders.Add("X-EBAY-C-MARKETPLACE-ID", "EBAY_US");

        // Getting json response
        HttpResponseMessage response = await httpClient.GetAsync(url);
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
        await using(FileStream fileStream = File.OpenRead(filePath)) {
            StreamContent fileContent = new(fileStream);
            fileContent.Headers.ContentType = new MediaTypeHeaderValue("multipart/form-data");

            form.Add(fileContent, "image", Path.GetFileName(filePath));
            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AppState.Instance.AccessToken);

            HttpResponseMessage response = await httpClient.PostAsync("https://apim.ebay.com/commerce/media/v1_beta/image/create_image_from_file", form);
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
}