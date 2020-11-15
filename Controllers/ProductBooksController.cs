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
    public class ProductBooksController : ControllerBase
    {
        private readonly SimpleStoreDbContext _context;

        public ProductBooksController(SimpleStoreDbContext context)
        {
            _context = context;
        }

        // GET: api/ProductBooks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductBook>>> GetProductBooks()
        {
            return await _context.ProductBooks.ToListAsync();
        }

        // GET: api/ProductBooks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductBook>> GetProductBook(string id)
        {
            var productBook = await _context.ProductBooks.FindAsync(id);

            if (productBook == null)
            {
                return NotFound();
            }

            return productBook;
        }

        // PUT: api/ProductBooks/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductBook(string id, ProductBook productBook)
        {
            if (id != productBook.Code)
            {
                return BadRequest();
            }

            _context.Entry(productBook).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductBookExists(id))
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

        // POST: api/ProductBooks
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ProductBook>> PostProductBook(ProductBook productBook)
        {
            _context.ProductBooks.Add(productBook);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProductBookExists(productBook.Code))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProductBook", new { id = productBook.Code }, productBook);
        }

        // DELETE: api/ProductBooks/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductBook>> DeleteProductBook(string id)
        {
            var productBook = await _context.ProductBooks.FindAsync(id);
            if (productBook == null)
            {
                return NotFound();
            }

            _context.ProductBooks.Remove(productBook);
            await _context.SaveChangesAsync();

            return productBook;
        }

        private bool ProductBookExists(string id)
        {
            return _context.ProductBooks.Any(e => e.Code == id);
        }
    }
}
