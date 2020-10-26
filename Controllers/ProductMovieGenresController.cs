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
    public class ProductMovieGenresController : ControllerBase
    {
        private readonly SimpleStoreDbContext _context;

        public ProductMovieGenresController(SimpleStoreDbContext context)
        {
            _context = context;
        }

        // GET: api/ProductMovieGenres
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductMovieGenre>>> GetProductMovieGenres()
        {
            return await _context.ProductMovieGenres.ToListAsync();
        }

        // GET: api/ProductMovieGenres/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductMovieGenre>> GetProductMovieGenre(Guid id)
        {
            var productMovieGenre = await _context.ProductMovieGenres.FindAsync(id);

            if (productMovieGenre == null)
            {
                return NotFound();
            }

            return productMovieGenre;
        }

        // PUT: api/ProductMovieGenres/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductMovieGenre(Guid id, ProductMovieGenre productMovieGenre)
        {
            if (id != productMovieGenre.Id)
            {
                return BadRequest();
            }

            _context.Entry(productMovieGenre).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductMovieGenreExists(id))
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

        // POST: api/ProductMovieGenres
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ProductMovieGenre>> PostProductMovieGenre(ProductMovieGenre productMovieGenre)
        {
            _context.ProductMovieGenres.Add(productMovieGenre);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductMovieGenre", new { id = productMovieGenre.Id }, productMovieGenre);
        }

        // DELETE: api/ProductMovieGenres/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductMovieGenre>> DeleteProductMovieGenre(Guid id)
        {
            var productMovieGenre = await _context.ProductMovieGenres.FindAsync(id);
            if (productMovieGenre == null)
            {
                return NotFound();
            }

            _context.ProductMovieGenres.Remove(productMovieGenre);
            await _context.SaveChangesAsync();

            return productMovieGenre;
        }

        private bool ProductMovieGenreExists(Guid id)
        {
            return _context.ProductMovieGenres.Any(e => e.Id == id);
        }
    }
}
