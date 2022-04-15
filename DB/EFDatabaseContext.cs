using DB.Entities;
using Microsoft.EntityFrameworkCore;

namespace DB;

public sealed class EfDatabaseContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public EfDatabaseContext()
    {
        Database.EnsureCreated();
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql("server=localhost;user=root;password=root;database=amd;", new MySqlServerVersion(new Version(8, 0, 27)));
    }
}