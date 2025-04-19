using System.Windows;
using System.Windows.Controls;

namespace Carbon;

public partial class MainWindow {
    private void ShowError(string errorMessage) {
        MessageBox.Show(errorMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
    }
    
    public MainWindow() {
        InitializeComponent();
    }

    private void NavbarButton_Click(object sender, RoutedEventArgs e) {
        if (sender is Button button && button.Content is string content) {
            switch (content) {
                case "Dashboard":
                    MainFrame.Navigate(new DashboardPage());
                    break;
                case "Inventory":
                    MainFrame.Navigate(new InventoryPage());
                    break;
                case "Listings":
                    MainFrame.Navigate(new ListingsPage());
                    break;
                case "Orders":
                    MainFrame.Navigate(new OrdersPage());
                    break;
                case "Pages":
                    MainFrame.Navigate(new PagesPage());
                    break;
                default:
                    ShowError($"Unknown Navbar button clicked: \"{content}\".\nSend a picture of this to me.");
                    break;
            }
        }
    }
}
