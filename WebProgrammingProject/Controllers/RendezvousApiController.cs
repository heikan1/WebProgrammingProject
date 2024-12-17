using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebProgrammingProject.Models.db;

namespace WebProgrammingProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RendezvousApiController : ControllerBase
    {
        private readonly Db _context;

        public RendezvousApiController(Db context)
        {
            _context = context;
        }

        // GET: api/RendezvousApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rendezvous>>> GetRendezvous_t()
        {
            return await _context.Rendezvous_t.ToListAsync();
        }

        // GET: api/RendezvousApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Rendezvous>> GetRendezvous(int id)
        {
            var rendezvous = await _context.Rendezvous_t.FindAsync(id);

            if (rendezvous == null)
            {
                return NotFound();
            }

            return rendezvous;
        }

        // PUT: api/RendezvousApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRendezvous(int id, Rendezvous rendezvous)
        {
            if (id != rendezvous.Id)
            {
                return BadRequest();
            }

            _context.Entry(rendezvous).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RendezvousExists(id))
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

        // POST: api/RendezvousApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Rendezvous>> PostRendezvous(Rendezvous rendezvous)
        {
            _context.Rendezvous_t.Add(rendezvous);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRendezvous", new { id = rendezvous.Id }, rendezvous);
        }

        // DELETE: api/RendezvousApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRendezvous(int id)
        {
            var rendezvous = await _context.Rendezvous_t.FindAsync(id);
            if (rendezvous == null)
            {
                return NotFound();
            }

            _context.Rendezvous_t.Remove(rendezvous);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RendezvousExists(int id)
        {
            return _context.Rendezvous_t.Any(e => e.Id == id);
        }
    }
}
