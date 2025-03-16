namespace Carbon;

public class InventoryItem(string name, string buyPrice, DateOnly buyDate, string location) {
    public string name { get; set; } = name;
    public string buyPrice { get; set; } = buyPrice;
    public DateOnly buyDate { get; set; } = buyDate;
    public string location { get; set; } = location;
}