namespace Carbon.Models;

public class InventoryItemModel {
    public string SKU { get; set; }
    public string Title { get; set; }
    public string Category { get; set; }
    public int Quantity { get; set; }
    public decimal Paid { get; set; }
    public string Location { get; set; }
    public string Bin { get; set; }
    public string Group { get; set; }
}