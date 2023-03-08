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
    [Authorize]
    public class ShopController : ControllerBase
    {
        readonly IShop _shop;
        public ShopController(IShop shop){
            _shop = shop;
        }

        [HttpGet]
        public ActionResult<List<Shop>> Get()
        {
            var response = new HttpResponseMessage();
            var Coki = new CookieHeaderValue("session-Id", "123");
            Coki.Expires = DateTimeOffset.Now.AddDays(2);
            Coki.Domain = Request.Host.ToString();   
            Coki.Path = "/";

            response.Headers.AddCookies(new CookieHeaderValue[] {Coki});

            return Ok(response);
            //return Ok(_shop.GetShopItems());
        }

        [HttpPost]
        public async Task<ActionResult<ShopItem>> PostShopItem(ShopItem shopItem)
        {
            await _shop.AddShopItems(shopItem); 

            return Ok();
        }

    }
}

/*
public ShopItemsController(ShopContext context)
{
    _context = context;
}

// GET: api/ShopItems
[HttpGet]
public async Task<ActionResult<IEnumerable<ShopItem>>> GetShopItems()
{
    return await _context.ShopItems.ToListAsync();
}

// GET: api/ShopItems/5
[HttpGet("{id}")]
public async Task<ActionResult<ShopItem>> GetShopItem(int id)
{
    var shopItem = await _context.ShopItems.FindAsync(id);

    if (shopItem == null)
    {
        return NotFound();
    }

    return shopItem;
}

// PUT: api/ShopItems/5
// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
[HttpPut("{id}")]
public async Task<IActionResult> PutShopItem(int id, ShopItem shopItem)
{
    if (id != shopItem.Id)
    {
        return BadRequest();
    }

    _context.Entry(shopItem).State = EntityState.Modified;

    try
    {
        await _context.SaveChangesAsync();
    }
    catch (DbUpdateConcurrencyException)
    {
        if (!ShopItemExists(id))
        {
            return NotFound();
        }
        else
        {
            throw;
        }
    }

    return NoContent();
}

// POST: api/ShopItems
// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
[HttpPost]
public async Task<ActionResult<ShopItem>> PostShopItem(ShopItem shopItem)
{
    _context.ShopItems.Add(shopItem);
    await _context.SaveChangesAsync();

    return CreatedAtAction("GetShopItem", new { id = shopItem.Id }, shopItem);
}

// DELETE: api/ShopItems/5
[HttpDelete("{id}")]
public async Task<IActionResult> DeleteShopItem(int id)
{
    var shopItem = await _context.ShopItems.FindAsync(id);
    if (shopItem == null)
    {
        return NotFound();
    }

    _context.ShopItems.Remove(shopItem);
    await _context.SaveChangesAsync();

    return NoContent();
}

private bool ShopItemExists(int id)
{
    return _context.ShopItems.Any(e => e.Id == id);
}
*/
