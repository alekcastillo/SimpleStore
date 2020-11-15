using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleStore.Entities;
using SimpleStore.Infrastructure;

namespace SimpleStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductSongsController : ControllerBase
    {
        private readonly SimpleStoreDbContext _context;

        public ProductSongsController(SimpleStoreDbContext context)
        {
            _context = context;
        }

        // GET: api/ProductSongs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductSong>>> GetProductSongs()
        {
            return await _context.ProductSongs.ToListAsync();
        }

        // GET: api/ProductSongs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductSong>> GetProductSong(string id)
        {
            var productSong = await _context.ProductSongs.FindAsync(id);

            if (productSong == null)
            {
                return NotFound();
            }

            return productSong;
        }

        // PUT: api/ProductSongs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductSong(string id, ProductSong productSong)
        {
            if (id != productSong.Code)
            {
                return BadRequest();
            }

            _context.Entry(productSong).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductSongExists(id))
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

        // POST: api/ProductSongs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ProductSong>> PostProductSong(ProductSong productSong)
        {
            _context.ProductSongs.Add(productSong);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProductSongExists(productSong.Code))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProductSong", new { id = productSong.Code }, productSong);
        }

        // DELETE: api/ProductSongs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductSong>> DeleteProductSong(string id)
        {
            var productSong = await _context.ProductSongs.FindAsync(id);
            if (productSong == null)
            {
                return NotFound();
            }

            _context.ProductSongs.Remove(productSong);
            await _context.SaveChangesAsync();

            return productSong;
        }

        private bool ProductSongExists(string id)
        {
            return _context.ProductSongs.Any(e => e.Code == id);
        }
    }
}
