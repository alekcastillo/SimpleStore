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
    public class ProductMovieActorsController : ControllerBase
    {
        private readonly SimpleStoreDbContext _context;

        public ProductMovieActorsController(SimpleStoreDbContext context)
        {
            _context = context;
        }

        // GET: api/ProductMovieActors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductMovieActor>>> GetProductMovieActors()
        {
            return await _context.ProductMovieActors.ToListAsync();
        }

        // GET: api/ProductMovieActors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductMovieActor>> GetProductMovieActor(Guid id)
        {
            var productMovieActor = await _context.ProductMovieActors.FindAsync(id);

            if (productMovieActor == null)
            {
                return NotFound();
            }

            return productMovieActor;
        }

        // PUT: api/ProductMovieActors/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductMovieActor(Guid id, ProductMovieActor productMovieActor)
        {
            if (id != productMovieActor.Id)
            {
                return BadRequest();
            }

            _context.Entry(productMovieActor).State = EntityState.Modified;

            ChangeLog.AddUpdatedLog(_context, "MovieActors", productMovieActor);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductMovieActorExists(id))
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

        // POST: api/ProductMovieActors
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ProductMovieActor>> PostProductMovieActor(ProductMovieActor productMovieActor)
        {
            _context.ProductMovieActors.Add(productMovieActor);

            ChangeLog.AddCreatedLog(_context, "MovieActors", productMovieActor);

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductMovieActor", new { id = productMovieActor.Id }, productMovieActor);
        }

        // DELETE: api/ProductMovieActors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductMovieActor>> DeleteProductMovieActor(Guid id)
        {
            var productMovieActor = await _context.ProductMovieActors.FindAsync(id);

            ChangeLog.AddDeletedLog(_context, "MovieActors", productMovieActor);

            if (productMovieActor == null)
            {
                return NotFound();
            }

            _context.ProductMovieActors.Remove(productMovieActor);
            await _context.SaveChangesAsync();

            return productMovieActor;
        }

        private bool ProductMovieActorExists(Guid id)
        {
            return _context.ProductMovieActors.Any(e => e.Id == id);
        }
    }
}
