using ConsoleApp3.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp3.Context;

public class SonyStoreDbContext:DbContext
{
    public DbSet<Products> Products { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=STHQ0126-14;Initial Catalog = SonyStore;User ID=admin;Password=admin;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        base.OnConfiguring(optionsBuilder);
    }
}
