using Microsoft.EntityFrameworkCore;

namespace ShopApi.Models;

// Many to One Table
public class ItemAddOn
{
    public int Id { get; set; }
    public string Name { get; set; }
    public float Price { get; set; }
    //public int ShopItemId { get; set; } // Foreign key to ShopItem
    //public ShopItem ShopItem { get; set; } // ShopItem Navigation property
}