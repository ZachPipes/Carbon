using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Text.Json;

namespace Carbon;

public partial class MainWindow {
    public MainWindow() {
        InitializeComponent();
        Utils.SetupAppDirectory();
        Utils.TokenUpdate();
    }

    private void NavbarButton_Click(object sender, RoutedEventArgs e) {
        ResetButtons();
        if (sender is not Button { Content: string content }) return;

        switch (content) {
            case "Dashboard":
                MainFrame.Navigate(new DashboardPage());
                DashboardButton.Foreground = new SolidColorBrush(Colors.Black);
                DashboardButton.Background = new SolidColorBrush(Color.FromArgb(255, 169, 169, 169));
                break;

            case "Inventory":
                MainFrame.Navigate(new InventoryPage());
                InventoryButton.Foreground = new SolidColorBrush(Colors.Black);
                InventoryButton.Background = new SolidColorBrush(Color.FromArgb(255, 169, 169, 169));
                break;

            case "Listings":
                MainFrame.Navigate(new ListingsPage());
                ListingsButton.Foreground = new SolidColorBrush(Colors.Black);
                ListingsButton.Background = new SolidColorBrush(Color.FromArgb(255, 169, 169, 169));
                break;

            case "Orders":
                MainFrame.Navigate(new OrdersPage());
                OrdersButton.Foreground = new SolidColorBrush(Colors.Black);
                OrdersButton.Background = new SolidColorBrush(Color.FromArgb(255, 169, 169, 169));
                break;

            case "Pages":
                MainFrame.Navigate(new PagesPage());
                PagesButton.Foreground = new SolidColorBrush(Colors.Black);
                PagesButton.Background = new SolidColorBrush(Color.FromArgb(255, 169, 169, 169));
                break;

            case "Settings":
                MainFrame.Navigate(new SettingsPage());
                SettingsButton.Foreground = new SolidColorBrush(Colors.Black);
                SettingsButton.Background = new SolidColorBrush(Color.FromArgb(255, 169, 169, 169));
                break;

            default:
                Utils.ShowError($"Unknown Navbar button clicked: \"{content}\".\nSend a picture of this to me.");
                break;
        }
    }

    private async void ListingCallTest(object sender, RoutedEventArgs e) {
        try {
            // Setting up the client/request
            using HttpClient client = new();
            string url = $"https://api.{AppState.Instance.API}ebay.com/sell/inventory/v1/inventory_item";
            HttpRequestMessage request = new(HttpMethod.Get, url);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", AppState.Instance.AccessToken);

            HttpResponseMessage response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode) {
                string responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Response body:");
                Console.WriteLine(responseBody);
            }
            else {
                Console.WriteLine($"Error: {(int)response.StatusCode} {response.ReasonPhrase}");
                string errorContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Error details:");
                Console.WriteLine(errorContent);
            }

        } catch (Exception ex) {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private async void UploadListingTest(object sender, RoutedEventArgs e) {
        try {
            // Setting up variables
            using var client = new HttpClient();
            string sku = $"UNQ-{DateTime.UtcNow:yyyyMMdd}-{Guid.NewGuid().ToString().Substring(0, 8)}";
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

    private void ResetButtons() {
        List<Button> buttons = [DashboardButton, InventoryButton, ListingsButton, OrdersButton, PagesButton, SettingsButton];

        foreach (Button button in buttons) {
            button.Background = new SolidColorBrush(Color.FromArgb(255, 45, 45, 48));
            button.Foreground = new SolidColorBrush(Colors.White);
        }
    }
}