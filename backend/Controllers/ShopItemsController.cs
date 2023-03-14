using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopApi.Models;
using InterfaceShop;
using ShopDemo;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Authorization;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    // Turn off while testing. Enables requirement for user authorization to access these api endpoints.
    //[Authorize]
    public class ShopController : ControllerBase
    {
        readonly IShop _shop;
        public ShopController(IShop shop){
            _shop = shop;
        }

        [HttpGet]
        public ActionResult<List<Shop>> Get()
        {
            var response = _shop.GetShopItems();

            return Ok(response);
        }

        [HttpGet("{id}")]
        public ActionResult<Shop> GetItem(int id)
        {
            var response = _shop.GetShopItem(id).Result;

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ShopItem>> PostShopItem(ShopItem shopItem)
        {
            await _shop.AddShopItems(shopItem); 

            return Ok();
        }

    }
}
