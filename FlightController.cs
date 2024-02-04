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
    public class FlightController : ControllerBase
    {
        private readonly Ace52024Context _context;

        public FlightController(Ace52024Context context)
        {
            _context = context;
        }

        // GET: api/Flight
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AryanFlight>>> GetAryanFlights()
        {
            return await _context.AryanFlights.ToListAsync();
        }

        // GET: api/Flight/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AryanFlight>> GetAryanFlight(int id)
        {
            var aryanFlight = await _context.AryanFlights.FindAsync(id);

            if (aryanFlight == null)
            {
                return NotFound();
            }

            return aryanFlight;
        }

        // PUT: api/Flight/5
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAryanFlight(int id, AryanFlight aryanFlight)
        {
            if (id != aryanFlight.FlightId)
            {
                return BadRequest();
            }

            _context.Entry(aryanFlight).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AryanFlightExists(id))
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

        // POST: api/Flight
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AryanFlight>> PostAryanFlight(AryanFlight aryanFlight)
        {
            _context.AryanFlights.Add(aryanFlight);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AryanFlightExists(aryanFlight.FlightId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAryanFlight", new { id = aryanFlight.FlightId }, aryanFlight);
        }

        // DELETE: api/Flight/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAryanFlight(int id)
        {
            var aryanFlight = await _context.AryanFlights.FindAsync(id);
            if (aryanFlight == null)
            {
                return NotFound();
            }

            _context.AryanFlights.Remove(aryanFlight);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AryanFlightExists(int id)
        {
            return _context.AryanFlights.Any(e => e.FlightId == id);
        }
    }
}
