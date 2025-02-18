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
    public class DicionariosController : ControllerBase
    {
        private readonly GabaritaContext _context;

        public DicionariosController(GabaritaContext context)
        {
            _context = context;
        }

        // GET: api/Dicionarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dicionario>>> GetDicionario()
        {
            return await _context.Dicionario.ToListAsync();
        }

        // GET: api/Dicionarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dicionario>> GetDicionario(int id)
        {
            var dicionario = await _context.Dicionario.FindAsync(id);

            if (dicionario == null)
            {
                return NotFound();
            }

            return dicionario;
        }

        // PUT: api/Dicionarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDicionario(int id, Dicionario dicionario)
        {
            if (id != dicionario.Id)
            {
                return BadRequest();
            }

            _context.Entry(dicionario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DicionarioExists(id))
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

        // POST: api/Dicionarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Dicionario>> PostDicionario(Dicionario dicionario)
        {
            _context.Dicionario.Add(dicionario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDicionario", new { id = dicionario.Id }, dicionario);
        }

        // DELETE: api/Dicionarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDicionario(int id)
        {
            var dicionario = await _context.Dicionario.FindAsync(id);
            if (dicionario == null)
            {
                return NotFound();
            }

            _context.Dicionario.Remove(dicionario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DicionarioExists(int id)
        {
            return _context.Dicionario.Any(e => e.Id == id);
        }
    }
}
