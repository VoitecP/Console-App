namespace Console_App;



    //public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

public class Product
{
    public int ProductId {get; set;}
    public string? ProductName {get; set;}
    public int? SupplierId {get; set;}
    public int? CategoryId {get; set;}
    public decimal? Price {get; set;}
    public Supplier? Supplier {get; set;}
    public Category? Category {get; set;}

}
