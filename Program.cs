using Microsoft.EntityFrameworkCore;

using ConsoleApp.Context;
using ConsoleApp.Services;
using ConsoleApp.Views;

class Program
{
    static void Main()
    {
        using var db = new AppDbContext();
        db.Database.Migrate();

        var service = new ProductService(db);

        while (true)
        {
            var menu = new MenuView();
            menu.Render();

            var key = Console.ReadKey(true).KeyChar;

            switch (key)
            {
                case '1':
                    new ProductListView(service.GetAll()).Render();
                    break;

                case '2':
                    var createView = new ProductCreateView();
                    createView.Render();
                    service.Create(createView.Product);
                    break;

                case '3':
                    return;
            }
        }
    }
}
