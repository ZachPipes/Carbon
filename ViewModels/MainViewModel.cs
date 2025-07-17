using Avalonia.Controls;
using Carbon.Views.DashboardPages;
using Carbon.Views.InventoryPages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Carbon.ViewModels;

public partial class MainViewModel : ObservableObject {
    [ObservableProperty] private UserControl _currentPage;

    public MainViewModel() {
        CurrentPage = new DashboardPage();
    }

    [RelayCommand]
    private void GoDashboardPage() {
        CurrentPage = new DashboardPage();
    }

    [RelayCommand]
    private void GoInventoryPage() {
        CurrentPage = new InventoryPage();
    }
}