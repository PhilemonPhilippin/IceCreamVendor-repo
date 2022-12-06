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
    public DbSet<IceCream> IceCreams { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Sell>().ToTable("Sell");
        modelBuilder.Entity<IceCream>().ToTable("IceCream");

        modelBuilder.Entity<Sell>(sell => sell.Property(s => s.Price).HasColumnType("decimal(18,2)"));
        modelBuilder.Entity<IceCream>(icecream => icecream.Property(ic => ic.Price).HasColumnType("decimal(18,2)"));

        modelBuilder.Entity<Sell>().HasData(
            new Sell()
            {
                Id = 1,
                IceCream = "vanilla",
                ClientName = "Philémon",
                Price = 1.50m
            });

        modelBuilder.Entity<IceCream>().HasData(
            new IceCream()
            {
                Id = 1,
                Flavour = "vanilla",
                Price = 1.50m
            },
            new IceCream()
            {
                Id = 2,
                Flavour = "chocolate",
                Price = 1.50m
            },
            new IceCream()
            {
                Id = 3,
                Flavour = "stracciatella",
                Price = 1.75m
            },
            new IceCream()
            {
                Id = 4,
                Flavour = "coffee",
                Price = 1.25m
            },
            new IceCream()
            {
                Id = 5,
                Flavour = "pistachio",
                Price = 1.80m,
            },
            new IceCream()
            {
                Id = 6,
                Flavour = "banana",
                Price = 1.25m

            },
            new IceCream()
            {
                Id = 7,
                Flavour = "lemon",
                Price = 1.25m
            },
            new IceCream()
            {
                Id = 8,
                Flavour = "coconut",
                Price = 1.99m
            },
            new IceCream()
            {
                Id = 9,
                Flavour = "strawberry",
                Price = 1.99m
            }
            );
    }
}
