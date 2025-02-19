using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Gabarita.Ai.Data;
using Gabarita.Ai.Models;

namespace Gabarita.Ai.Migrations
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesempenhosController : ControllerBase
    {
        private readonly GabaritaContext _context;

        public DesempenhosController(GabaritaContext context)
        {
            _context = context;
        }

        // GET: api/Desempenhos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Desempenho>>> GetDesempenho()
        {
            return await _context.Desempenho.ToListAsync();
        }

        // GET: api/Desempenhos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Desempenho>> GetDesempenho(Guid id)
        {
            var desempenho = await _context.Desempenho.FindAsync(id);

            if (desempenho == null)
            {
                return NotFound();
            }

            return desempenho;
        }

        // PUT: api/Desempenhos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDesempenho(Guid id, Desempenho desempenho)
        {
            if (id != desempenho.DesempenhoId)
            {
                return BadRequest();
            }

            _context.Entry(desempenho).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DesempenhoExists(id))
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

        // POST: api/Desempenhos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Desempenho>> PostDesempenho(Desempenho desempenho)
        {
            _context.Desempenho.Add(desempenho);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDesempenho", new { id = desempenho.DesempenhoId }, desempenho);
        }

        // DELETE: api/Desempenhos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDesempenho(Guid id)
        {
            var desempenho = await _context.Desempenho.FindAsync(id);
            if (desempenho == null)
            {
                return NotFound();
            }

            _context.Desempenho.Remove(desempenho);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DesempenhoExists(Guid id)
        {
            return _context.Desempenho.Any(e => e.DesempenhoId == id);
        }
    }
}
