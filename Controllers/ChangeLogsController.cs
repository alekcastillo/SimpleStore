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
    public class ChangeLogsController : ControllerBase
    {
        private readonly SimpleStoreDbContext _context;

        public ChangeLogsController(SimpleStoreDbContext context)
        {
            _context = context;
        }

        // GET: api/UserRoles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChangeLog>>> GetChangeLogs()
        {
            return await _context.ChangeLogs.ToListAsync();
        }
    }
}
