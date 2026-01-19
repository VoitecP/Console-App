using Microsoft.EntityFrameworkCore;
using Console_App.Models;

namespace Console_App.Data;

public class AppDbContext : DbContext
{
    public DbSet<Customer> Customers => Set<Customer>();

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer(
            "Server=.;Database=TestDb;Trusted_Connection=True;TrustServerCertificate=True"
        );
    }

    // ⬇⬇⬇ TU WSTAWIASZ OnModelCreating ⬇⬇⬇
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId);

            entity.Property(e => e.CustomerName)
                  .HasMaxLength(100)
                  .IsRequired();

            entity.Property(e => e.ContactName)
                  .HasMaxLength(100);

            entity.Property(e => e.Country)
                  .HasMaxLength(50);
        });
    }
}