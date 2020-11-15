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
    public class DownloadLogsController : ControllerBase
    {
        private readonly SimpleStoreDbContext _context;

        public DownloadLogsController(SimpleStoreDbContext context)
        {
            _context = context;
        }

        // GET: api/DownloadLogs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DownloadLog>>> GetDownloadLogs()
        {
            return await _context.DownloadLogs.ToListAsync();
        }

        // GET: api/DownloadLogs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DownloadLog>> GetDownloadLog(Guid id)
        {
            var downloadLog = await _context.DownloadLogs.FindAsync(id);

            if (downloadLog == null)
            {
                return NotFound();
            }

            return downloadLog;
        }

        // PUT: api/DownloadLogs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDownloadLog(Guid id, DownloadLog downloadLog)
        {
            if (id != downloadLog.Id)
            {
                return BadRequest();
            }

            _context.Entry(downloadLog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DownloadLogExists(id))
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

        // POST: api/DownloadLogs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DownloadLog>> PostDownloadLog(DownloadLog downloadLog)
        {
            _context.DownloadLogs.Add(downloadLog);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDownloadLog", new { id = downloadLog.Id }, downloadLog);
        }

        // DELETE: api/DownloadLogs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DownloadLog>> DeleteDownloadLog(Guid id)
        {
            var downloadLog = await _context.DownloadLogs.FindAsync(id);
            if (downloadLog == null)
            {
                return NotFound();
            }

            _context.DownloadLogs.Remove(downloadLog);
            await _context.SaveChangesAsync();

            return downloadLog;
        }

        private bool DownloadLogExists(Guid id)
        {
            return _context.DownloadLogs.Any(e => e.Id == id);
        }
    }
}
