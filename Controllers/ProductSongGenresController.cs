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
    public class ProductSongGenresController : ControllerBase
    {
        private readonly SimpleStoreDbContext _context;

        public ProductSongGenresController(SimpleStoreDbContext context)
        {
            _context = context;
        }

        // GET: api/ProductSongGenres
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductSongGenre>>> GetProductSongGenres()
        {
            return await _context.ProductSongGenres.ToListAsync();
        }

        // GET: api/ProductSongGenres/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductSongGenre>> GetProductSongGenre(Guid id)
        {
            var productSongGenre = await _context.ProductSongGenres.FindAsync(id);

            if (productSongGenre == null)
            {
                return NotFound();
            }

            return productSongGenre;
        }

        // PUT: api/ProductSongGenres/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductSongGenre(Guid id, ProductSongGenre productSongGenre)
        {
            if (id != productSongGenre.Id)
            {
                return BadRequest();
            }

            _context.Entry(productSongGenre).State = EntityState.Modified;

            ChangeLog.AddUpdatedLog(_context, "SongGenres", productSongGenre);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductSongGenreExists(id))
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

        // POST: api/ProductSongGenres
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ProductSongGenre>> PostProductSongGenre(ProductSongGenre productSongGenre)
        {
            _context.ProductSongGenres.Add(productSongGenre);

            ChangeLog.AddCreatedLog(_context, "SongGenres", productSongGenre);

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductSongGenre", new { id = productSongGenre.Id }, productSongGenre);
        }

        // DELETE: api/ProductSongGenres/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductSongGenre>> DeleteProductSongGenre(Guid id)
        {
            var productSongGenre = await _context.ProductSongGenres.FindAsync(id);

            ChangeLog.AddDeletedLog(_context, "SongGenres", productSongGenre);

            if (productSongGenre == null)
            {
                return NotFound();
            }

            _context.ProductSongGenres.Remove(productSongGenre);
            await _context.SaveChangesAsync();

            return productSongGenre;
        }

        private bool ProductSongGenreExists(Guid id)
        {
            return _context.ProductSongGenres.Any(e => e.Id == id);
        }
    }
}
