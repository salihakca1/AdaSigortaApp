using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AdaSigortaAppYeniWebApi.Data;
using AdaSigortaAppYeniWebApi.Models;

namespace AdaSigortaAppYeniWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DasksController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DasksController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Dasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dask>>> GetDask()
        {
            if (_context.Dask == null)
            {
                return NotFound();
            }


            var DaskList = await _context.Dask
                        .Include(t => t.Person)
                        .Include(t => t.Product)
                        .ToListAsync();

            return DaskList;
        }

        // GET: api/Dasks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dask>> GetDask(int id)
        {
          if (_context.Dask == null)
          {
              return NotFound();
          }
            var dask = await _context.Dask.FindAsync(id);

            if (dask == null)
            {
                return NotFound();
            }

            return dask;
        }

        // PUT: api/Dasks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDask(int id, Dask dask)
        {
            if (id != dask.PolicyId)
            {
                return BadRequest();
            }

            _context.Entry(dask).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DaskExists(id))
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

        // POST: api/Dasks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Dask>> PostDask(Dask dask)
        {
          if (_context.Dask == null)
          {
              return Problem("Entity set 'AppDbContext.Dask'  is null.");
          }
            _context.Dask.Add(dask);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDask", new { id = dask.PolicyId }, dask);
        }

        // DELETE: api/Dasks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDask(int id)
        {
            if (_context.Dask == null)
            {
                return NotFound();
            }
            var dask = await _context.Dask.FindAsync(id);
            if (dask == null)
            {
                return NotFound();
            }

            _context.Dask.Remove(dask);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DaskExists(int id)
        {
            return (_context.Dask?.Any(e => e.PolicyId == id)).GetValueOrDefault();
        }
    }
}
