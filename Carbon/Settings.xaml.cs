using System.Windows;
using System.Windows.Controls;

namespace Carbon;

public partial class SettingsPage : Page {
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
}