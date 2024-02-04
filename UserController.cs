using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using airyan.Models;

namespace airyan.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly Ace52024Context _context;

        public UserController(Ace52024Context context)
        {
            _context = context;
        }
        [HttpPost("authenticate")]
        public ActionResult<ApiResponse> AuthenticateUser(AryanUser user)
        {
            var result = _context.AryanUsers
                .Any(u => u.Username == user.Username && u.Password == user.Password);

            if (result)
            {
                return new ApiResponse { Success = true };
            }
            else
            {
                return new ApiResponse { Success = false };
            }
        }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AryanUser>>> GetAryanUsers()
        {
            return await _context.AryanUsers.ToListAsync();
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AryanUser>> GetAryanUser(int id)
        {
            var aryanUser = await _context.AryanUsers.FindAsync(id);

            if (aryanUser == null)
            {
                return NotFound();
            }

            return aryanUser;
        }

        // PUT: api/User/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAryanUser(int id, AryanUser aryanUser)
        {
            if (id != aryanUser.UserId)
            {
                return BadRequest();
            }

            _context.Entry(aryanUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AryanUserExists(id))
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

        // POST: api/User
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AryanUser>> PostAryanUser(AryanUser aryanUser)
        {
            _context.AryanUsers.Add(aryanUser);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAryanUser", new { id = aryanUser.UserId }, aryanUser);
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAryanUser(int id)
        {
            var aryanUser = await _context.AryanUsers.FindAsync(id);
            if (aryanUser == null)
            {
                return NotFound();
            }

            _context.AryanUsers.Remove(aryanUser);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AryanUserExists(int id)
        {
            return _context.AryanUsers.Any(e => e.UserId == id);
        }
    }
}
