using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Carbon.Views.SettingsPages;

public partial class SettingsPage : UserControl {
    public SettingsPage() {
        InitializeComponent();
        
        // DataContext = new SettingsViewModel;
    }
}