using Microsoft.EntityFrameworkCore;

using ShopApi.Models;

namespace InterfaceShop;

public interface IShop{
    public List<ShopItem> GetShopItems();

    public Task<ShopItem> GetShopItem(int id);
    public Task<ShopItem> AddShopItems(ShopItem itemToAdd); 
}