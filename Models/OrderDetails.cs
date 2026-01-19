namespace Console_App.Models;

public class OrderDetails
{
    public int OrderDetailsId {get; set;}
    public int OrderId {get; set;}
    public int ProductId {get; set;}
    public int Quantity {get; set;}
    public Order? Order {get; set;}
    public Product? Product {get; set;}

}
