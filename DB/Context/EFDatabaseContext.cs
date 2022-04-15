using DB.Entities;
using Microsoft.EntityFrameworkCore;

namespace DB.Context;

public sealed class EfDatabaseContext : DbContext, IContext
{
    public DbSet<User> Users { get; set; }

    public EfDatabaseContext()
    {
        Database.EnsureCreated();
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql(MainContext.ConnectionString, new MySqlServerVersion(new Version(8, 0, 27)));
    }
}