using Microsoft.EntityFrameworkCore;
using ConsoleApp.Models;

namespace ConsoleApp.Context;

public class AppDbContext : DbContext
{
    public AppDbContext()
    {
        
    }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    public DbSet<Customer> Customer {get; set;}
    public DbSet<Employee> Employee {get; set;}
    public DbSet<Category> Category {get; set;}
    public DbSet<Supplier> Supplier {get; set;}
    public DbSet<Product> Product {get; set;}
    public DbSet<Shipper> Shipper {get; set;}
    public DbSet<Order> Order {get; set;}
    public DbSet<OrderDetails> OrderDetails {get; set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlite("Data source=Db/database.db");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId);
            entity.Property(e =>e.CustomerName)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.ContactName)
                .HasMaxLength(100);
            entity.Property(e => e.Country)
                .HasMaxLength(100);
        });
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50);
            entity.Property(e => e.LastName)
                .HasMaxLength(50);
        });
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId);
            entity.Property(e => e.CategoryName)
                .HasMaxLength(50);
        });
        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.SupplierId);
            entity.Property(e => e.SupplierName)
                .HasMaxLength(100);
            entity.Property(e => e.Country)
                .HasMaxLength(50);    
        });
        // modelBuilder.Entity<Product>(entity =>
        // {
        //     entity.HasKey(e => e.ProductId);
        //     entity.Property(e => e.ProductName)
        //         .HasMaxLength(100);
        //     entity.Property(e => e.Price)
        //         .HasColumnType("decimal(10,2)");
        //     entity.HasKey(e => e.SupplierId)
        //         .HasName("PK_Supplier");
        //     entity.HasKey(e => e.CategoryId)
        //         .HasName("PK_Category");
        // });

        modelBuilder.Entity<Product>(entity =>
        {
            //entity.ToTable("Product");

            entity.HasKey(e => e.ProductId); 
            entity.Property(e => e.ProductId)
                .HasColumnName("ProductID")
                .ValueGeneratedOnAdd();
            entity.Property(e => e.ProductName)
                .HasColumnName("ProductName")
                .HasMaxLength(100);
            entity.Property(e => e.Price)
                .HasColumnName("Price")
                .HasColumnType("decimal(10,2)")
                .HasPrecision(10, 2);
            entity.Property(e => e.SupplierId)
                .HasColumnName("SupplierID");
            entity.Property(e => e.CategoryId)
                .HasColumnName("CategoryID");
            entity.HasOne(e => e.Supplier)
                .WithMany()                           
                .HasForeignKey(e => e.SupplierId)
                .OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(e => e.Category)
                .WithMany()
                .HasForeignKey(e => e.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Shipper>(entity => 
        {
            entity.HasKey(e => e.ShipperId);
            entity.Property(e => e.ShipperName)
                .HasColumnName("ShipperName")
                .HasMaxLength(50);
            
        });

        modelBuilder.Entity<Order>(entity =>
        {
            //entity.ToTable("Order");                      // nazwa tabeli w bazie
            entity.HasKey(e => e.OrderId);                 // primary key
            entity.Property(e => e.OrderId)
                .HasColumnName("OrderID")
                .ValueGeneratedOnAdd(); 
            entity.Property(e => e.OrderDate)
                .HasColumnName("OrderDate")
                .HasColumnType("date");                  // IDENTITY / auto-increment
            entity.Property(e => e.CustomerId)
                .HasColumnName("CustomerID");
            entity.Property(e => e.EmployeeId)
                .HasColumnName("EmployeeID");
          
            entity.Property(e => e.ShipperId)
                .HasColumnName("ShipperID");
            // Relacja do Customer (najczęściej wymagana NOT NULL w Northwind, ale w Twojej tabeli bez NOT NULL → nullable)
            entity.HasOne(e => e.Customer)
                .WithMany()                
                .HasForeignKey(e => e.CustomerId)
                //.HasConstraintName("FK_Order_Customers")
                .OnDelete(DeleteBehavior.Restrict);      // Restrict / NoAction – najczęściej w zamówieniach

            // Relacja do Employee (pracownik, który przyjął zamówienie)
            entity.HasOne(e => e.Employee)
                .WithMany()                 
                .HasForeignKey(e => e.EmployeeId)
                //.HasConstraintName("FK_Orders_Employees")
                .OnDelete(DeleteBehavior.Restrict);

            // Relacja do Shipper (firma spedycyjna)
            entity.HasOne(e => e.Shipper)
                .WithMany()               
                .HasForeignKey(e => e.ShipperId)
                //.HasConstraintName("FK_Orders_Shippers")
                .OnDelete(DeleteBehavior.SetNull);       // często SetNull – zamówienie zostaje, nawet jak przewoźnik zniknie
        });

        

        modelBuilder.Entity<OrderDetails>(entity =>
        {
            entity.HasKey(e => e.OrderDetailsId);

            entity.Property(e => e.OrderDetailsId)
                  .ValueGeneratedOnAdd();

            entity.HasOne(e => e.Order)
                  .WithMany()
                  .HasForeignKey(e => e.OrderId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Product)
                  .WithMany()
                  .HasForeignKey(e => e.ProductId)
                  .OnDelete(DeleteBehavior.Restrict);
        });
    }





}