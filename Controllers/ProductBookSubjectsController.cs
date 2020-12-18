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
    public class ProductBookSubjectsController : ControllerBase
    {
        private readonly SimpleStoreDbContext _context;

        public ProductBookSubjectsController(SimpleStoreDbContext context)
        {
            _context = context;
        }

        // GET: api/ProductBookSubjects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductBookSubject>>> GetProductBookSubjects()
        {
            return await _context.ProductBookSubjects.ToListAsync();
        }

        // GET: api/ProductBookSubjects/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductBookSubject>> GetProductBookSubject(Guid id)
        {
            var productBookSubject = await _context.ProductBookSubjects.FindAsync(id);

            if (productBookSubject == null)
            {
                return NotFound();
            }

            return productBookSubject;
        }

        // PUT: api/ProductBookSubjects/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductBookSubject(Guid id, ProductBookSubject productBookSubject)
        {
            if (id != productBookSubject.Id)
            {
                return BadRequest();
            }

            _context.Entry(productBookSubject).State = EntityState.Modified;

            ChangeLog.AddUpdatedLog(_context, "BookSubjects", productBookSubject);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductBookSubjectExists(id))
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

        // POST: api/ProductBookSubjects
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ProductBookSubject>> PostProductBookSubject(ProductBookSubject productBookSubject)
        {
            _context.ProductBookSubjects.Add(productBookSubject);

            ChangeLog.AddCreatedLog(_context, "BookSubjects", productBookSubject);

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductBookSubject", new { id = productBookSubject.Id }, productBookSubject);
        }

        // DELETE: api/ProductBookSubjects/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductBookSubject>> DeleteProductBookSubject(Guid id)
        {
            var productBookSubject = await _context.ProductBookSubjects.FindAsync(id);

            ChangeLog.AddDeletedLog(_context, "BookSubjects", productBookSubject);

            if (productBookSubject == null)
            {
                return NotFound();
            }

            _context.ProductBookSubjects.Remove(productBookSubject);
            await _context.SaveChangesAsync();

            return productBookSubject;
        }

        private bool ProductBookSubjectExists(Guid id)
        {
            return _context.ProductBookSubjects.Any(e => e.Id == id);
        }
    }
}
