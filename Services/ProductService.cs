using ConsoleApp.Context;
using ConsoleApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp.Services;

public class ProductService
{
    private readonly AppDbContext _db;

    public ProductService(AppDbContext db)
    {
        _db = db;
    }

    public List<Product> GetAll()
        => _db.Product.AsNoTracking().ToList();

    public Product? Get(int id)
        => _db.Product.Find(id);

    public void Create(Product p)
    {
        _db.Product.Add(p);
        _db.SaveChanges();
    }

    public void Update(Product p)
    {
        _db.SaveChanges();
    }

    public void Delete(Product p)
    {
        _db.Product.Remove(p);
        _db.SaveChanges();
    }
}
