using System;
using Avalonia.Controls;
using Carbon.Views.DashboardPages;
using Carbon.Views.InventoryPages;
using Carbon.Views.ListingsPages;
using Carbon.Views.OrdersPages;
using Carbon.Views.SettingsPages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Carbon.ViewModels;

public partial class MainViewModel : ObservableObject {
    [ObservableProperty] private UserControl _currentPage;
    [ObservableProperty] private string _selectedSection;

    public MainViewModel() {
        CurrentPage = new DashboardPage();
        SelectedSection = "Dashboard";
    }

    [RelayCommand]
    private void NavbarButton(string parameter) {
        SelectedSection = parameter;
        CurrentPage = parameter switch {
            "Dashboard" => new DashboardPage(),
            "Inventory" => new InventoryPage(),
            "Listings" => new ListingsPage(),
            "Orders" => new OrdersPage(),
            "Settings" => new SettingsPage(),
            _ => throw new InvalidOperationException($"NavbarButton() - Unknown parameter: {parameter}")
        };
    }
}