namespace Carbon;

public class ListingsItem(InventoryItem inventoryItem, /*Images, */ string category, DateOnly listedDate) {
    // Inherited from inventoryItem
    public string name { get; set; } = inventoryItem.name;
    public string buyPrice { get; set; } = inventoryItem.buyPrice;
    public DateOnly buyDate { get; set; } = inventoryItem.buyDate;
    public string location { get; set; } = inventoryItem.location;

    // ListingsItem attributes
    public string category { get; set; } = category;
    public DateOnly listedDate { get; set; } = listedDate;
}