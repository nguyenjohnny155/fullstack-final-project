using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopApi.Models;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopItemsController : ControllerBase
    {
        private readonly ShopContext _context;

        public ShopItemsController(ShopContext context)
        {
            _context = context;
        }

        // GET: api/ShopItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShopItem>>> GetShopItems()
        {
          if (_context.ShopItems == null)
          {
              return NotFound();
          }
            return await _context.ShopItems.ToListAsync();
        }

        // GET: api/ShopItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ShopItem>> GetShopItem(long id)
        {
          if (_context.ShopItems == null)
          {
              return NotFound();
          }
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
        public async Task<IActionResult> PutShopItem(long id, ShopItem shopItem)
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
          if (_context.ShopItems == null)
          {
              return Problem("Entity set 'ShopContext.ShopItems'  is null.");
          }
            _context.ShopItems.Add(shopItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShopItem", new { id = shopItem.Id }, shopItem);
        }

        // DELETE: api/ShopItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShopItem(long id)
        {
            if (_context.ShopItems == null)
            {
                return NotFound();
            }
            var shopItem = await _context.ShopItems.FindAsync(id);
            if (shopItem == null)
            {
                return NotFound();
            }

            _context.ShopItems.Remove(shopItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ShopItemExists(long id)
        {
            return (_context.ShopItems?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
