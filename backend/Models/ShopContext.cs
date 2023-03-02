using Microsoft.EntityFrameworkCore;

namespace ShopApi.Models;

public class ShopContext : DbContext 
{

    public DbSet<ShopItem> ShopItems { get; set; }
    public DbSet<ItemAddOn> ItemAddOns { get; set; }

    protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder) {
        optionsBuilder.UseInMemoryDatabase(databaseName: "ShopDb");
    }

}

    /*
    public ShopContext( DbContextOptions<ShopContext> options) : base(options)
    {

    }
    */

    /*    
    protected override void OnModelCreating( ModelBuilder modelBuilder ){

        Console.WriteLine("MODEL BUILDER HAS BEEN EXECUTED!");
        modelBuilder.Entity<ItemAddOn>()
            .HasOne<ShopItem>(s => s.ShopItem)
            .WithMany(g => g.ItemAddOns)
            .HasForeignKey(s => s.ShopItemId);
    }
    */