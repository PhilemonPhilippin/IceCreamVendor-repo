using IceCreamVendor.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamVendor.Core.Data;

public class IceCreamContext : DbContext
{
    public IceCreamContext(DbContextOptions<IceCreamContext> options): base(options)
    {
    }

    public DbSet<Sell> Sells { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Sell>().ToTable("Sell");

        modelBuilder.Entity<Sell>(sell => sell.Property(s => s.Price).HasColumnType("decimal(18,2)"));

        modelBuilder.Entity<Sell>().HasData(
            new Sell()
            {
                Id = 1,
                IceCream = "vanilla",
                ClientName = "Philémon",
                Price = 1.75m
            });
    }
}
