﻿using System;
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
    public class TableConsecutivesController : ControllerBase
    {
        private readonly SimpleStoreDbContext _context;

        public TableConsecutivesController(SimpleStoreDbContext context)
        {
            _context = context;
        }

        // GET: api/TableConsecutives
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TableConsecutive>>> GetTableConsecutives()
        {
            return await _context.TableConsecutives.ToListAsync();
        }

        // GET: api/TableConsecutives/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TableConsecutive>> GetTableConsecutive(Guid id)
        {
            var tableConsecutive = await _context.TableConsecutives.FindAsync(id);

            if (tableConsecutive == null)
            {
                return NotFound();
            }

            return tableConsecutive;
        }

        // PUT: api/TableConsecutives/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTableConsecutive(Guid id, TableConsecutive tableConsecutive)
        {
            if (id != tableConsecutive.Id)
            {
                return BadRequest();
            }

            _context.Entry(tableConsecutive).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TableConsecutiveExists(id))
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

        // POST: api/TableConsecutives
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TableConsecutive>> PostTableConsecutive(TableConsecutive tableConsecutive)
        {
            _context.TableConsecutives.Add(tableConsecutive);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTableConsecutive", new { id = tableConsecutive.Id }, tableConsecutive);
        }

        // DELETE: api/TableConsecutives/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TableConsecutive>> DeleteTableConsecutive(Guid id)
        {
            var tableConsecutive = await _context.TableConsecutives.FindAsync(id);
            if (tableConsecutive == null)
            {
                return NotFound();
            }

            _context.TableConsecutives.Remove(tableConsecutive);
            await _context.SaveChangesAsync();

            return tableConsecutive;
        }

        private bool TableConsecutiveExists(Guid id)
        {
            return _context.TableConsecutives.Any(e => e.Id == id);
        }
    }
}
