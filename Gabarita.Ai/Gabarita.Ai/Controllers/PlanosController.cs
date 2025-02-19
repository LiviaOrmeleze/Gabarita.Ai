using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Gabarita.Ai.Data;
using Gabarita.Ai.Models;

namespace Gabarita.Ai.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanosController : ControllerBase
    {
        private readonly GabaritaContext _context;

        public PlanosController(GabaritaContext context)
        {
            _context = context;
        }

        // GET: api/Planos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Planos>>> GetPlanos()
        {
            return await _context.Planos.ToListAsync();
        }

        // GET: api/Planos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Planos>> GetPlanos(Guid id)
        {
            var planos = await _context.Planos.FindAsync(id);

            if (planos == null)
            {
                return NotFound();
            }

            return planos;
        }

        // PUT: api/Planos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlanos(Guid id, Planos planos)
        {
            if (id != planos.PlanosId)
            {
                return BadRequest();
            }

            _context.Entry(planos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlanosExists(id))
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

        // POST: api/Planos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Planos>> PostPlanos(Planos planos)
        {
            _context.Planos.Add(planos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlanos", new { id = planos.PlanosId }, planos);
        }

        // DELETE: api/Planos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlanos(Guid id)
        {
            var planos = await _context.Planos.FindAsync(id);
            if (planos == null)
            {
                return NotFound();
            }

            _context.Planos.Remove(planos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlanosExists(Guid id)
        {
            return _context.Planos.Any(e => e.PlanosId == id);
        }
    }
}
