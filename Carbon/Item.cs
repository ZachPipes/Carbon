using System.ComponentModel.DataAnnotations;

namespace Carbon;

public class Item(string name, decimal price, DateOnly buyDate, int quantity) {
    // Primary constructor
    public string Name { get; set; } = name;
    public decimal Price { get; set; } = price;
    public DateOnly BuyDate { get; set; } = buyDate;
    public int Quantity { get; set; } = quantity;
}