using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleStore.Entities;
using SimpleStore.DAO;
using SimpleStore.Infrastructure;
using System.Web.Http;
using Microsoft.AspNetCore.Cors;
using System.Web.Http.Cors;

namespace SimpleStore.Controllers
{
    [System.Web.Http.Cors.EnableCors(origins: "*", headers: "*", methods: "*")]
    [Produces("application/json")]
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly SimpleStoreDbContext _context;

        public UsersController(SimpleStoreDbContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [Microsoft.AspNetCore.Mvc.HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/Users/5
        [Microsoft.AspNetCore.Mvc.HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(Guid id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Microsoft.AspNetCore.Mvc.HttpPut("{id}")]
        public async Task<IActionResult> PutUser(Guid id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/Users
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        
                [Microsoft.AspNetCore.Mvc.HttpPost]
                public async Task<ActionResult> PostUser([Microsoft.AspNetCore.Mvc.FromBody] User user)//user en minuscula es una clase nueva, User en mayuscula es el entity
                {

                    _context.Users.Add(user);
                    await _context.SaveChangesAsync();
                    return CreatedAtAction("GetUser", new { id = user.Id }, user);
                }
        
        /*
        [System.Web.Http.HttpPost]
        //CREAR USUARIO
        public IHttpActionResult PostUser([System.Web.Http.FromBody] User user)
        {
            if (ModelState.IsValid)
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return (IHttpActionResult)Ok(user);
            }
            else
            {
                return (IHttpActionResult)BadRequest();
            }
        }
        */

        // DELETE: api/Users/5
        [Microsoft.AspNetCore.Mvc.HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return user;
        }

        private bool UserExists(Guid id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
