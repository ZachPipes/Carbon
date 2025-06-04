using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Carbon;

public partial class ListingsPage {
    private ObservableCollection<ListingItem> items { get; set; }
    private ObservableCollection<ListingItem> filteredItems { get; set; }
    public ObservableCollection<string> UniqueCats { get; set; }
    private ObservableCollection<string> SelectedCats { get; set; }
    
    public ListingsPage() {
        InitializeComponent();
        // TODO: Make searches cross compatible, ie I can use search by name and by category at the same time

        //items = Utils.LoadFile("Listings", ListingDataGrid);
        filteredItems = new ObservableCollection<ListingItem>(items);
        ListingDataGrid.ItemsSource = filteredItems;

        UniqueCats = new ObservableCollection<string>(items.Select(p => p.Category).Distinct());
        SelectedCats = new ObservableCollection<string>();

        DataContext = this;
    }
    private void AddListingButton_OnClick(object sender, RoutedEventArgs e) {
        throw new NotImplementedException();
    }
    
    private void SearchBoxTextChange(object sender, TextChangedEventArgs e) {
        //ApplyFilter("name");
    }
}

public class ListingItem {
    public required string Name { get; set; }
    public required string Category { get; set; }
    public required decimal Price { get; set; }
}