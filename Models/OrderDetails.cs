namespace ConsoleApp.Models;

public class OrderDetails
{
    public int OrderDetailsId {get; set;}
    public int OrderId {get; set;}
    public int ProductId {get; set;}
    public int Quantity {get; set;}
    public Order? Order {get; set;}
    public Product? Product {get; set;}

    //public ICollection<OrderDetails> OrderDetails { get; set; } = new List<OrderDetails>();
}
