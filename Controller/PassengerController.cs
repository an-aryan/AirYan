using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using airyan.Models;
using airyan.Service;
using airyan.Repository;

namespace airyan.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassengerController : ControllerBase
    {
        // private readonly Ace52024Context _context;
        private readonly IPassServ<AryanPassenger> _passengerServ;
        // public PassengerController(Ace52024Context context)
        // {
        //     _context = context;
        // }
        public PassengerController(IPassServ<AryanPassenger> passengerServ)
        {
            _passengerServ = passengerServ;
        }

        // GET: api/Passenger
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AryanPassenger>>> GetAryanPassengers()
        {
            return await _passengerServ.GetAllPassengers();
        }

        // GET: api/Passenger/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AryanPassenger>> GetAryanPassenger(int id)
        {
            var aryanPassenger = _passengerServ.GetPassengerbyId(id);

            if (aryanPassenger == null)
            {
                return NotFound();
            }

            return await aryanPassenger;
        }

        // PUT: api/Passenger/5

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAryanPassenger(int id, AryanPassenger aryanPassenger)
        {
            if (id != aryanPassenger.PassengerId)
            {
                return BadRequest();
            }

            // _context.Entry(aryanPassenger).State = EntityState.Modified;

            try
            {
                await _passengerServ.UpdatePassenger(id, aryanPassenger);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await AryanPassengerExists(id))
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

        // POST: api/Passenger
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AryanPassenger>> PostAryanPassenger(AryanPassenger aryanPassenger)
        {
            try {
                 await _passengerServ.AddPassenger(aryanPassenger);
            }
            catch (DbUpdateException)
            {
                if(await AryanPassengerExists(aryanPassenger.PassengerId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAryanPassenger", new { id = aryanPassenger.PassengerId }, aryanPassenger);
        }

        // DELETE: api/Passenger/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAryanPassenger(int id)
        {
            var aryanPassenger = await _passengerServ.GetPassengerbyId(id);
            if (aryanPassenger == null)
            {
                return NotFound();
            }

            await _passengerServ.DeletePassenger(id);

            return NoContent();
        }

        private async Task<bool> AryanPassengerExists(int id)
        {
            AryanPassenger p = await _passengerServ.GetPassengerbyId(id);
            if(p!=null)
            {
                return true;
            }
            return false;
        }
    }
}
