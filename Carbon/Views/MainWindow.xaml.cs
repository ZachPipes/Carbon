using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Carbon;

public partial class MainWindow {
    public MainWindow() {
        InitializeComponent();
        Utils.SetupAppDirectory();
        Utils.TokenUpdate();
    }

    private void NavbarButton_Click(object sender, RoutedEventArgs e) {
        ResetButtons();
        if(sender is not Button { Content: string content }) return;

        switch(content) {
            case "Dashboard":
                MainFrame.Navigate(new DashboardPage());
                DashboardButton.Foreground = new SolidColorBrush(Colors.Black);
                DashboardButton.Background = new SolidColorBrush(Color.FromArgb(255, 169, 169, 169));
                break;

            case "InventoryPages":
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

    private void ResetButtons() {
        List<Button> buttons = [DashboardButton, InventoryButton, ListingsButton, OrdersButton, SettingsButton];

        foreach(Button button in buttons) {
            button.Background = new SolidColorBrush(Color.FromArgb(255, 45, 45, 48));
            button.Foreground = new SolidColorBrush(Colors.White);
        }
    }
}