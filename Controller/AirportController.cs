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
    public class AirportController : ControllerBase
    {
        private readonly Ace52024Context _context;

        public AirportController(Ace52024Context context)
        {
            _context = context;
        }

        // GET: api/Airport
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AryanAirport>>> GetAryanAirports()
        {
            return await _context.AryanAirports.ToListAsync();
        }

        // GET: api/Airport/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AryanAirport>> GetAryanAirport(int id)
        {
            var aryanAirport = await _context.AryanAirports.FindAsync(id);

            if (aryanAirport == null)
            {
                return NotFound();
            }

            return aryanAirport;
        }

        // PUT: api/Airport/5
    
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAryanAirport(int id, AryanAirport aryanAirport)
        {
            if (id != aryanAirport.AirportId)
            {
                return BadRequest();
            }

            _context.Entry(aryanAirport).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AryanAirportExists(id))
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

        // POST: api/Airport
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AryanAirport>> PostAryanAirport(AryanAirport aryanAirport)
        {
            _context.AryanAirports.Add(aryanAirport);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AryanAirportExists(aryanAirport.AirportId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAryanAirport", new { id = aryanAirport.AirportId }, aryanAirport);
        }

        // DELETE: api/Airport/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAryanAirport(int id)
        {
            var aryanAirport = await _context.AryanAirports.FindAsync(id);
            if (aryanAirport == null)
            {
                return NotFound();
            }

            _context.AryanAirports.Remove(aryanAirport);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AryanAirportExists(int id)
        {
            return _context.AryanAirports.Any(e => e.AirportId == id);
        }
    }
}
