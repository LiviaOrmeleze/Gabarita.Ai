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
    public class AlternativasController : ControllerBase
    {
        private readonly GabaritaContext _context;

        public AlternativasController(GabaritaContext context)
        {
            _context = context;
        }

        // GET: api/Alternativas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Alternativa>>> GetAlternativa()
        {
            return await _context.Alternativa.ToListAsync();
        }

        // GET: api/Alternativas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Alternativa>> GetAlternativa(Guid id)
        {
            var alternativa = await _context.Alternativa.FindAsync(id);

            if (alternativa == null)
            {
                return NotFound();
            }

            return alternativa;
        }

        // PUT: api/Alternativas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlternativa(Guid id, Alternativa alternativa)
        {
            if (id != alternativa.AlternativaId)
            {
                return BadRequest();
            }

            _context.Entry(alternativa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlternativaExists(id))
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

        // POST: api/Alternativas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Alternativa>> PostAlternativa(Alternativa alternativa)
        {
            _context.Alternativa.Add(alternativa);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAlternativa", new { id = alternativa.AlternativaId }, alternativa);
        }

        // DELETE: api/Alternativas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlternativa(Guid id)
        {
            var alternativa = await _context.Alternativa.FindAsync(id);
            if (alternativa == null)
            {
                return NotFound();
            }

            _context.Alternativa.Remove(alternativa);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AlternativaExists(Guid id)
        {
            return _context.Alternativa.Any(e => e.AlternativaId == id);
        }
    }
}
