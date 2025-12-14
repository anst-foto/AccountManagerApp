using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace AccountManagerApp.DAL;

public class DataBaseContextFactory : IDesignTimeDbContextFactory<DataBaseContext>
{
    public DataBaseContext CreateDbContext(string[] args)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var connectionString = config.GetConnectionString("DefaultConnection");

        var optionsBuilder = new DbContextOptionsBuilder<DataBaseContext>();
        optionsBuilder.UseNpgsql(connectionString);

        return new DataBaseContext(optionsBuilder.Options);
    }
}
