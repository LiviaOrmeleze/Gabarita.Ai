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
    public class VestibulandosController : ControllerBase
    {
        private readonly GabaritaContext _context;

        public VestibulandosController(GabaritaContext context)
        {
            _context = context;
        }

        // GET: api/Vestibulandos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vestibulando>>> GetVestibulando()
        {
            return await _context.Vestibulando.ToListAsync();
        }

        // GET: api/Vestibulandos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vestibulando>> GetVestibulando(Guid id)
        {
            var vestibulando = await _context.Vestibulando.FindAsync(id);

            if (vestibulando == null)
            {
                return NotFound();
            }

            return vestibulando;
        }

        // PUT: api/Vestibulandos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVestibulando(Guid id, Vestibulando vestibulando)
        {
            if (id != vestibulando.VestibulandoId)
            {
                return BadRequest();
            }

            _context.Entry(vestibulando).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VestibulandoExists(id))
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

        // POST: api/Vestibulandos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Vestibulando>> PostVestibulando(Vestibulando vestibulando)
        {
            _context.Vestibulando.Add(vestibulando);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVestibulando", new { id = vestibulando.VestibulandoId }, vestibulando);
        }

        // DELETE: api/Vestibulandos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVestibulando(Guid id)
        {
            var vestibulando = await _context.Vestibulando.FindAsync(id);
            if (vestibulando == null)
            {
                return NotFound();
            }

            _context.Vestibulando.Remove(vestibulando);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VestibulandoExists(Guid id)
        {
            return _context.Vestibulando.Any(e => e.VestibulandoId == id);
        }
    }
}
