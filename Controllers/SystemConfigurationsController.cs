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
    public class SystemConfigurationsController : ControllerBase
    {
        private readonly SimpleStoreDbContext _context;

        public SystemConfigurationsController(SimpleStoreDbContext context)
        {
            _context = context;
        }

        // GET: api/SystemConfigurations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SystemConfiguration>>> GetSystemConfigurations()
        {
            return await _context.SystemConfigurations.ToListAsync();
        }

        // GET: api/SystemConfigurations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SystemConfiguration>> GetSystemConfiguration(Guid id)
        {
            var systemConfiguration = await _context.SystemConfigurations.FindAsync(id);

            if (systemConfiguration == null)
            {
                return NotFound();
            }

            return systemConfiguration;
        }

        // PUT: api/SystemConfigurations/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSystemConfiguration(Guid id, SystemConfiguration systemConfiguration)
        {
            if (id != systemConfiguration.Id)
            {
                return BadRequest();
            }

            _context.Entry(systemConfiguration).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SystemConfigurationExists(id))
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

        // POST: api/SystemConfigurations
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<SystemConfiguration>> PostSystemConfiguration(SystemConfiguration systemConfiguration)
        {
            _context.SystemConfigurations.Add(systemConfiguration);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSystemConfiguration", new { id = systemConfiguration.Id }, systemConfiguration);
        }

        // DELETE: api/SystemConfigurations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SystemConfiguration>> DeleteSystemConfiguration(Guid id)
        {
            var systemConfiguration = await _context.SystemConfigurations.FindAsync(id);
            if (systemConfiguration == null)
            {
                return NotFound();
            }

            _context.SystemConfigurations.Remove(systemConfiguration);
            await _context.SaveChangesAsync();

            return systemConfiguration;
        }

        private bool SystemConfigurationExists(Guid id)
        {
            return _context.SystemConfigurations.Any(e => e.Id == id);
        }
    }
}
