using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Carbon;

public partial class MainWindow {
    public MainWindow() {
        InitializeComponent();
        Utils.SetupAppDirectory();
        AppState.Instance.CheckForTokenUpdate();
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

            default:
                Utils.ShowError($"Unknown Navbar button clicked: \"{content}\".\nSend a picture of this to me.");
                break;
        }
    }

    private void ResetButtons() {
        var buttons = new List<Button> { DashboardButton, InventoryButton, ListingsButton, OrdersButton, PagesButton };

        foreach (var button in buttons) {
            button.Background = new SolidColorBrush(Color.FromArgb(255, 45, 45, 48));
            button.Foreground = new SolidColorBrush(Colors.White);
        }
    }

    private async void SettingsButton_Click(object sender, RoutedEventArgs e) {
        try {
            AuthenticationState.LaunchAuthFlow();
            await AuthenticationState.Instance.ExecuteEbayAuth();
        } catch (Exception ex) {
            MessageBox.Show($"Authorization failed: {ex.Message}");
        }
    }

    // private async void TestButton_OnClick_Click(object sender, RoutedEventArgs e) {
    //     using var client = new HttpClient();
    //
    //     // Set the Authorization header with your token
    //     client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", EBayAuth.GetAccessToken());
    //
    //     // Define the API endpoint (sandbox version)
    //     var endpoint = "https://api.sandbox.ebay.com/buy/browse/v1/item_summary/search?q=laptop&limit=5";
    //
    //     // Send the request to the API
    //     var response = await client.GetAsync(endpoint);
    //     var jsonResponse = await response.Content.ReadAsStringAsync();
    //     
    //     // Handle an error
    //     if (!response.IsSuccessStatusCode) {
    //         Console.WriteLine($"Error: {response.StatusCode}");
    //         string errorResponse = await response.Content.ReadAsStringAsync();
    //         Console.WriteLine($"Error details: {errorResponse}");
    //     }
    // }
}