using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;

namespace Carbon;

public class ApiFunctions {
    public static async Task GetInventory() {
        try {
            const string limit = "100", offset = "0";
            string url = $"https://api.{AppState.Instance.API}ebay.com/sell/inventory/v1/inventory_item?limit={limit}&offset={offset}";
         
            using HttpClient client = new();
            HttpRequestMessage request = new(HttpMethod.Get, url);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", AppState.Instance.AccessToken);
         
            HttpResponseMessage response = await client.SendAsync(request);
         
            if (response.IsSuccessStatusCode) {
                string json = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Success:\n" + json);
            }
            else {
                Console.WriteLine($"Failed: {response.StatusCode}");
                string error = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Error Response:\n" + error);
            }
         
        } catch (Exception ex) {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    public static async Task UploadInventoryItem() {
        try {
            // Setting up variables
            using var client = new HttpClient();
            string sku = $"UNQ-{DateTime.UtcNow:yyyyMMdd}-{Guid.NewGuid().ToString().Substring(0, 8)}";
            Console.WriteLine($"SKU: {sku}");
            string url = $"https://api.{AppState.Instance.API}ebay.com/sell/inventory/v1/inventory_item/{sku}";
            var payload = new {
                sku,
                product = new {
                    title = "Sample eBay Item Title",
                    description = "This is a sample item description for eBay listing.",
                    aspects = new {
                        Brand = new[] { "SampleBrand" },
                        Color = new[] { "Black" },
                        Size = new[] { "M" }
                    }
                },
                condition = "NEW",
                price = new {
                    currency = "USD",
                    value = "19.99"
                },
                availability = new {
                    shipToLocationAvailability = new {
                        quantity = 10
                    }
                }
            };
            string jsonPayload = JsonSerializer.Serialize(payload);

            HttpRequestMessage request = new(HttpMethod.Put, url) {
                Content = new StringContent(jsonPayload, System.Text.Encoding.UTF8, "application/json")
            };
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", AppState.Instance.AccessToken);
            request.Content.Headers.ContentLanguage.Add("en-US");


            HttpResponseMessage response = await client.SendAsync(request);

            //TODO: Handle the response better
            if (response.IsSuccessStatusCode) {
                string responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Code: {response.StatusCode}\nResponse: {responseBody}");
            }
            else {
                Console.WriteLine($"Error: {(int)response.StatusCode} {response.ReasonPhrase}");
                string errorBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine(errorBody);
            }
        } catch (Exception ex) {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}