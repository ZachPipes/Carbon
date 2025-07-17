using Avalonia.Controls;
using Carbon.ViewModels.InventoryViewModels;

namespace Carbon.Views.InventoryPages;

public partial class AddInventoryItemWindow : Window {
    public AddInventoryItemWindow() {
        DataContext = new AddInventoryItemViewModel();
        
        InitializeComponent();
    }
    
    private void OnCellEditEnded(object? sender, DataGridCellEditEndedEventArgs e) {
        if (DataContext is AddInventoryItemViewModel vm) {
            vm.OnItemEdited();
        }
    }
}