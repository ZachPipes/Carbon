using System.Windows.Controls;

namespace Carbon;

public partial class ListingsPage : Page {
    private List<Product> _allProducts;
    public ListingsPage() {
        InitializeComponent();
        
        _allProducts = new List<Product> {
            new Product { Name = "Apple", Category = "Fruit", Price = 0.5m },
            new Product { Name = "Carrot", Category = "Vegetable", Price = 0.3m },
            new Product { Name = "Banana", Category = "Fruit", Price = 0.4m },
        };
        
        ProductDataGrid.ItemsSource = _allProducts;
        
        var categories = _allProducts.Select(p => p.Category).Distinct().ToList();
        CategoryFilter.ItemsSource = categories;
    }
}

public class Product {
    public string Name { get; set; }
    public string Category { get; set; }
    public decimal Price { get; set; }
}