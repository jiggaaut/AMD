using DB.Entities;
using DB.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace DB.Context;

public sealed class EfDatabaseContext : DbContext, IContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Auth> Auths { get; set; }

    public EfDatabaseContext()
    {
        //Database.EnsureDeleted();
        Database.EnsureCreated();
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql(MainContext.ConnectionString, new MySqlServerVersion(new Version(8, 0, 27)));
    }

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    base.OnModelCreating(modelBuilder);
    //}
}