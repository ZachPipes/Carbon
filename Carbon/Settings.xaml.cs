using System.Windows;
using System.Windows.Controls;

namespace Carbon;

public partial class SettingsPage {
    public SettingsPage() {
        InitializeComponent();
    }

    public async void Authenticate(object sender, RoutedEventArgs e) {
        try {
            AuthenticationState.LaunchAuthFlow();
            await AuthenticationState.Instance.ExecuteEbayAuth();
        } catch (Exception ex) {
            MessageBox.Show($"Authorization failed: {ex.Message}");
        }
    }

    public void PrintToken(object sender, RoutedEventArgs e) {
        Console.WriteLine($"Token: <<< {AppState.Instance.AccessToken} >>>");
    }

    private void SwitchAPI(object sender, RoutedEventArgs e) {
        if (AppState.Instance.API == "sandbox.") {
            AppState.Instance.API = "";
            Console.WriteLine("Switched API to : PROD");
        }
        else {
            AppState.Instance.API = "sandbox.";
            Console.WriteLine("Switched API to : SANDBOX");
        }
    }
}