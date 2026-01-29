namespace ConsoleApp.Views;

public class MenuView : IView
{
    public void Render()
    {
        Console.Clear();
        Console.WriteLine("=== PRODUCT MANAGER ===");
        Console.WriteLine("1. Product list");
        Console.WriteLine("2. Add product");
        Console.WriteLine("3. Exit");
        Console.WriteLine("----------------------");
        Console.Write("Choice: ");
    }
}
