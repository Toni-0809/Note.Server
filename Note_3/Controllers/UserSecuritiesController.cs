using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Note_3.Data;
using Note_3.Entities;

namespace Note_3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserSecuritiesController : ControllerBase
    {
        private readonly DataContext _context;

        public UserSecuritiesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/UserSecurities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserSecurity>>> GetUserSecurity()
        {
            return await _context.UserSecurity.ToListAsync();
        }

        // GET: api/UserSecurities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserSecurity>> GetUserSecurity(int id)
        {
            var userSecurity = await _context.UserSecurity.FindAsync(id);

            if (userSecurity == null)
            {
                return NotFound();
            }

            return userSecurity;
        }

        // PUT: api/UserSecurities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserSecurity(int id, UserSecurity userSecurity)
        {
            if (id != userSecurity.Id)
            {
                return BadRequest();
            }

            _context.Entry(userSecurity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserSecurityExists(id))
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

        // POST: api/UserSecurities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserSecurity>> PostUserSecurity(UserSecurity userSecurity)
        {
            _context.UserSecurity.Add(userSecurity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserSecurity", new { id = userSecurity.Id }, userSecurity);
        }

        // DELETE: api/UserSecurities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserSecurity(int id)
        {
            var userSecurity = await _context.UserSecurity.FindAsync(id);
            if (userSecurity == null)
            {
                return NotFound();
            }

            _context.UserSecurity.Remove(userSecurity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserSecurityExists(int id)
        {
            return _context.UserSecurity.Any(e => e.Id == id);
        }
    }
}
