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
    public class ComunidadesController : ControllerBase
    {
        private readonly GabaritaContext _context;

        public ComunidadesController(GabaritaContext context)
        {
            _context = context;
        }

        // GET: api/Comunidades
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Comunidades>>> GetComunidades()
        {
            return await _context.Comunidades.ToListAsync();
        }

        // GET: api/Comunidades/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Comunidades>> GetComunidades(Guid id)
        {
            var comunidades = await _context.Comunidades.FindAsync(id);

            if (comunidades == null)
            {
                return NotFound();
            }

            return comunidades;
        }

        // PUT: api/Comunidades/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComunidades(Guid id, Comunidades comunidades)
        {
            if (id != comunidades.ComunidadesId)
            {
                return BadRequest();
            }

            _context.Entry(comunidades).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComunidadesExists(id))
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

        // POST: api/Comunidades
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Comunidades>> PostComunidades(Comunidades comunidades)
        {
            _context.Comunidades.Add(comunidades);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetComunidades", new { id = comunidades.ComunidadesId }, comunidades);
        }

        // DELETE: api/Comunidades/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComunidades(Guid id)
        {
            var comunidades = await _context.Comunidades.FindAsync(id);
            if (comunidades == null)
            {
                return NotFound();
            }

            _context.Comunidades.Remove(comunidades);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ComunidadesExists(Guid id)
        {
            return _context.Comunidades.Any(e => e.ComunidadesId == id);
        }
    }
}
