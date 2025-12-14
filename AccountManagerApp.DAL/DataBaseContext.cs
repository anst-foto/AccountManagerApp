using AccountManagerApp.Models;
using Microsoft.EntityFrameworkCore;

namespace AccountManagerApp.DAL;

public class DataBaseContext : DbContext
{
    public DbSet<Account> Accounts { get; set; }

    public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options) { }
}
