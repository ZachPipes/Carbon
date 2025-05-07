using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Carbon;

public partial class InventoryPage {
    private ObservableCollection<InventoryItem> items { get; set; }
    private ObservableCollection<InventoryItem> filteredItems { get; set; }
    public ObservableCollection<string> UniqueCats { get; set; }
    private ObservableCollection<string> SelectedCats { get; set; }

    public InventoryPage() {
        InitializeComponent();
        // TODO: Make searches cross compatible, ie I can use search by name and by category at the same time

        items = Utils.LoadFile("Inventory");
        filteredItems = new ObservableCollection<InventoryItem>(items);
        InventoryDataGrid.ItemsSource = filteredItems;

        UniqueCats = new ObservableCollection<string>(items.Select(p => p.Category).Distinct());
        SelectedCats = new ObservableCollection<string>();

        DataContext = this;
    }

    private void AddInventoryButton_OnClick(object sender, RoutedEventArgs e) {
        throw new NotImplementedException();
    }

    private void CatChkbx_Checked(object sender, RoutedEventArgs e) {
        if (sender is CheckBox checkBox && checkBox.Content is string category) {
            if (!SelectedCats.Contains(category))
                SelectedCats.Add(category);
            ApplyFilter();
        }
    }

    private void CatChkbx_Unchecked(object sender, RoutedEventArgs e) {
        if (sender is CheckBox checkBox && checkBox.Content is string category) {
            SelectedCats.Remove(category);
            ApplyFilter();
        }
    }

    private void ApplyFilter() {
        var filtered = items.AsEnumerable();
        
        if (!string.IsNullOrWhiteSpace(SearchBox.Text)) {
            filtered = filtered.Where(i => i.Name.Contains(SearchBox.Text, StringComparison.OrdinalIgnoreCase));
        }

        if (SelectedCats.Any()) {
            filtered = filtered.Where(i => SelectedCats.Contains(i.Category));
        }

        filteredItems.Clear();
        foreach (var item in filtered)
            filteredItems.Add(item);
    }

    private void SearchBoxTextChange(object sender, TextChangedEventArgs e) {
        ApplyFilter();
    }
}

public class InventoryItem {
    public required string Name { get; set; }
    public required string Category { get; set; }
    public required double Paid { get; set; }
    public required string Location { get; set; }
    public required string Bin { get; set; }
}