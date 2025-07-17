using Avalonia.Controls;
using Carbon.ViewModels;
using Carbon.ViewModels.InventoryViewModels;

namespace Carbon.Views.InventoryPages;

public partial class InventoryPage : UserControl {
    public InventoryPage() {
        InitializeComponent();
        
        DataContext = new InventoryViewModel();
    }
}