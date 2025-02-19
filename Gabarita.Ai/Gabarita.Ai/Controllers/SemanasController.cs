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
    public class SemanasController : ControllerBase
    {
        private readonly GabaritaContext _context;

        public SemanasController(GabaritaContext context)
        {
            _context = context;
        }

        // GET: api/Semanas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Semana>>> GetSemana()
        {
            return await _context.Semana.ToListAsync();
        }

        // GET: api/Semanas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Semana>> GetSemana(Guid id)
        {
            var semana = await _context.Semana.FindAsync(id);

            if (semana == null)
            {
                return NotFound();
            }

            return semana;
        }

        // PUT: api/Semanas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSemana(Guid id, Semana semana)
        {
            if (id != semana.SemanaId)
            {
                return BadRequest();
            }

            _context.Entry(semana).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SemanaExists(id))
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

        // POST: api/Semanas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Semana>> PostSemana(Semana semana)
        {
            _context.Semana.Add(semana);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSemana", new { id = semana.SemanaId }, semana);
        }

        // DELETE: api/Semanas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSemana(Guid id)
        {
            var semana = await _context.Semana.FindAsync(id);
            if (semana == null)
            {
                return NotFound();
            }

            _context.Semana.Remove(semana);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SemanaExists(Guid id)
        {
            return _context.Semana.Any(e => e.SemanaId == id);
        }
    }
}
