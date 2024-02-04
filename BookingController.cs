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
    public class BookingController : ControllerBase
    {
        private readonly Ace52024Context _context;

        public BookingController(Ace52024Context context)
        {
            _context = context;
        }

        // GET: api/Booking
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AryanBooking>>> GetAryanBookings()
        {
            return await _context.AryanBookings.ToListAsync();
        }

        // GET: api/Booking/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AryanBooking>> GetAryanBooking(int id)
        {
            var aryanBooking = await _context.AryanBookings.FindAsync(id);

            if (aryanBooking == null)
            {
                return NotFound();
            }

            return aryanBooking;
        }

        // PUT: api/Booking/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAryanBooking(int id, AryanBooking aryanBooking)
        {
            if (id != aryanBooking.BookingId)
            {
                return BadRequest();
            }

            _context.Entry(aryanBooking).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AryanBookingExists(id))
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

        // POST: api/Booking
       
        [HttpPost]
        public async Task<ActionResult<AryanBooking>> PostAryanBooking(AryanBooking aryanBooking)
        {
            _context.AryanBookings.Add(aryanBooking);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAryanBooking", new { id = aryanBooking.BookingId }, aryanBooking);
        }

        // DELETE: api/Booking/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAryanBooking(int id)
        {
            var aryanBooking = await _context.AryanBookings.FindAsync(id);
            if (aryanBooking == null)
            {
                return NotFound();
            }

            _context.AryanBookings.Remove(aryanBooking);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AryanBookingExists(int id)
        {
            return _context.AryanBookings.Any(e => e.BookingId == id);
        }
    }
}
