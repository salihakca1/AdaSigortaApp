using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AdaSigortaAppYeniWebApi.Data;
using AdaSigortaAppYeniWebApi.Models;

namespace AdaSigortaAppYeniWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrafficController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TrafficController(AppDbContext context)
        {
            _context = context;
        }


        // GET: api/Traffic
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Traffic>>> GetTrafik()
        {
            if (_context.Trafik == null)
            {
                return NotFound();
            }


            var trafficList = await _context.Trafik
                .Include(t => t.Person)
                .Include(t => t.Product)
                .ToListAsync();

            return trafficList;
        }

        // GET: api/Traffic/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Traffic>> GetTraffic(int id)
        {
          if (_context.Trafik == null)
          {
              return NotFound();
          }
            var traffic = await _context.Trafik.FindAsync(id);

            if (traffic == null)
            {
                return NotFound();
            }

            return traffic;
        }

        // PUT: api/Traffic/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTraffic(int id, Traffic traffic)
        {
            if (id != traffic.PolicyId)
            {
                return BadRequest();
            }

            _context.Entry(traffic).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrafficExists(id))
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

        // POST: api/Traffic
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Traffic>> PostTraffic(Traffic traffic)
        {
          if (_context.Trafik == null)
          {
              return Problem("Entity set 'AppDbContext.Trafik'  is null.");
          }
            _context.Trafik.Add(traffic);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTraffic", new { id = traffic.PolicyId }, traffic);
        }

        // DELETE: api/Traffic/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTraffic(int id)
        {
            if (_context.Trafik == null)
            {
                return NotFound();
            }
            var traffic = await _context.Trafik.FindAsync(id);
            if (traffic == null)
            {
                return NotFound();
            }

            _context.Trafik.Remove(traffic);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TrafficExists(int id)
        {
            return (_context.Trafik?.Any(e => e.PolicyId == id)).GetValueOrDefault();
        }
    }
}
