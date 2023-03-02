using ShopApi.Models;
using Microsoft.EntityFrameworkCore;

using InterfaceShop;
namespace ShopDemo;

public class Shop : IShop
{
    public Shop()
    {
        /*
        using (var context = new ShopContext())
        {
           var shopItem = new List<ShopItem>
           {
            new ShopItem
            {

                ItemName = "PhobGCC Gamecube",
                ItemBasePrice = 249.99f,
                ItemAddOns = new List<ItemAddOn>()
                {
                    new ItemAddOn { Name = "L/R Trigger Mods", Price = 19.99f}
                }
            },
            new ShopItem
            {
                ItemName = "PhobGCC 2.0.2 Motherboard",
                ItemBasePrice = 59.99f,
                ItemAddOns = new List<ItemAddOn>()
                {
                    new ItemAddOn { Name = "Mouseclick Z", Price = 19.99f}
                }
            },
           };

           context.ShopItems.AddRange(shopItem);
           context.SaveChanges();
        }
        */
    }    
    public List<ShopItem> GetShopItems()
    {
        using (var context = new ShopContext())
        {
            var list = context.ShopItems
                .Include(a => a.ItemAddOns)
                .ToList(); 
            return list;
        }
    }

    public async Task<ShopItem> AddShopItems(ShopItem itemToAdd)
    {
        await using (var context = new ShopContext()) 
        {
            var list = context.ShopItems.Add(new ShopItem {
                ItemName = itemToAdd.ItemName,
                ItemBasePrice = itemToAdd.ItemBasePrice,
                ItemAddOns = new List<ItemAddOn> {
                    new ItemAddOn { Name = itemToAdd.ItemAddOns[0].Name, Price = itemToAdd.ItemAddOns[0].Price} 
                }
            });

            context.SaveChanges();
            return itemToAdd;
        }
    }
}


