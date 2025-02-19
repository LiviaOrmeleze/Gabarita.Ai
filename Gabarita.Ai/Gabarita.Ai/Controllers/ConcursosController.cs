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
    public class ConcursosController : ControllerBase
    {
        private readonly GabaritaContext _context;

        public ConcursosController(GabaritaContext context)
        {
            _context = context;
        }

        // GET: api/Concursos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Concurso>>> GetConcurso()
        {
            return await _context.Concurso.ToListAsync();
        }

        // GET: api/Concursos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Concurso>> GetConcurso(Guid id)
        {
            var concurso = await _context.Concurso.FindAsync(id);

            if (concurso == null)
            {
                return NotFound();
            }

            return concurso;
        }

        // PUT: api/Concursos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConcurso(Guid id, Concurso concurso)
        {
            if (id != concurso.ConcursoId)
            {
                return BadRequest();
            }

            _context.Entry(concurso).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConcursoExists(id))
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

        // POST: api/Concursos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Concurso>> PostConcurso(Concurso concurso)
        {
            _context.Concurso.Add(concurso);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConcurso", new { id = concurso.ConcursoId }, concurso);
        }

        // DELETE: api/Concursos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConcurso(Guid id)
        {
            var concurso = await _context.Concurso.FindAsync(id);
            if (concurso == null)
            {
                return NotFound();
            }

            _context.Concurso.Remove(concurso);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ConcursoExists(Guid id)
        {
            return _context.Concurso.Any(e => e.ConcursoId == id);
        }
    }
}
