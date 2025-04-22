using System.Windows;
using System.Windows.Controls;

namespace Carbon;

public partial class InventoryPage : Page {
    public InventoryPage() {
        InitializeComponent();
    }
    
    private void AddInventoryButton_OnClick(object sender, RoutedEventArgs e) {
        throw new NotImplementedException();
    }
}

public class InventoryItem {
    public string Name { get; set; }
    public string Category { get; set; }
    public double Paid { get; set; }
    public string Location { get; set; }
    public string Bin { get; set; }
}
