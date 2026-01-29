using ConsoleApp.Models;
namespace ConsoleApp.Views;

public class ProductListView : IView
{
    private readonly List<Product> _products;

    public ProductListView(List<Product> products)
    {
        _products = products;
    }

    public void Render()
    {
        Console.Clear();
        Console.WriteLine("ID | NAME | PRICE");
        Console.WriteLine("---------------------");

        foreach (var p in _products)
        {
            Console.WriteLine($"{p.ProductId,2} | {p.ProductName,-15} | {p.Price,8:C}");
        }

        Console.WriteLine();
        Console.Write("ENTER = return");
        Console.ReadLine();
    }
}
