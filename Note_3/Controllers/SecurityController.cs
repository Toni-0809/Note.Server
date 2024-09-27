using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Note_3.Data;
using Note_3.DTOs;
using Note_3.Mapper;
using Note_3.Utilities;

namespace Note_3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private readonly DataContext _context;

        public SecurityController(DataContext context)
        {
            _context = context;
        }

        [HttpPost("/register")]
        public async Task<ActionResult> Register(SecurityRequest user)
        {
            _context.UserSecurity.Add(user.ToEntity());
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPost("/login")]
        public async Task<ActionResult<SecurityResponse>> Login(SecurityRequest user)
        {
            var found = await _context.UserSecurity
            .FirstOrDefaultAsync(p => p.Login == user.Login && p.Password == Encoder.ComputeSHA256Hash(user.Password));

            return found != null ? Ok(found) : BadRequest();

        }

    }
}
