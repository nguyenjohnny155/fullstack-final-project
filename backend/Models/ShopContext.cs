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
