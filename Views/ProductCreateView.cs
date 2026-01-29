using ConsoleApp.Models;
using ConsoleApp.Views;

public class ProductCreateView : IView
{
    public Product Product { get; private set; } = new();

    public void Render()
    {
        Console.Clear();
        Console.WriteLine("=== DODAJ PRODUKT ===");

        Console.Write("Nazwa: ");
        Product.ProductName = Console.ReadLine() ?? "";

        Console.Write("Cena: ");
        decimal.TryParse(Console.ReadLine(), out var price);
        Product.Price = price;
    }
}
