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
    public class TemasController : ControllerBase
    {
        private readonly GabaritaContext _context;

        public TemasController(GabaritaContext context)
        {
            _context = context;
        }

        // GET: api/Temas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Temas>>> GetTemas()
        {
            return await _context.Temas.ToListAsync();
        }

        // GET: api/Temas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Temas>> GetTemas(Guid id)
        {
            var temas = await _context.Temas.FindAsync(id);

            if (temas == null)
            {
                return NotFound();
            }

            return temas;
        }

        // PUT: api/Temas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTemas(Guid id, Temas temas)
        {
            if (id != temas.TemasId)
            {
                return BadRequest();
            }

            _context.Entry(temas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TemasExists(id))
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

        // POST: api/Temas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Temas>> PostTemas(Temas temas)
        {
            _context.Temas.Add(temas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTemas", new { id = temas.TemasId }, temas);
        }

        // DELETE: api/Temas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTemas(Guid id)
        {
            var temas = await _context.Temas.FindAsync(id);
            if (temas == null)
            {
                return NotFound();
            }

            _context.Temas.Remove(temas);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TemasExists(Guid id)
        {
            return _context.Temas.Any(e => e.TemasId == id);
        }
    }
}
