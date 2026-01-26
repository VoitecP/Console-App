using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ConsoleApp.Context;

public class AppDbContextFactory
    : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

        // optionsBuilder.UseSqlServer(
        //     "Server=.;Database=datasetDB;Trusted_Connection=True;TrustServerCertificate=True");


        optionsBuilder.UseSqlite(
            "Data Source=Db/Database.db");
        
        return new AppDbContext(optionsBuilder.Options);
    }
}
