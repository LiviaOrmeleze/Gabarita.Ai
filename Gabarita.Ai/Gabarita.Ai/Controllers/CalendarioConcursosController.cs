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
    public class CalendarioConcursosController : ControllerBase
    {
        private readonly GabaritaContext _context;

        public CalendarioConcursosController(GabaritaContext context)
        {
            _context = context;
        }

        // GET: api/CalendarioConcursos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CalendarioConcurso>>> GetCalendarioConcurso()
        {
            return await _context.CalendarioConcurso.ToListAsync();
        }

        // GET: api/CalendarioConcursos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CalendarioConcurso>> GetCalendarioConcurso(int id)
        {
            var calendarioConcurso = await _context.CalendarioConcurso.FindAsync(id);

            if (calendarioConcurso == null)
            {
                return NotFound();
            }

            return calendarioConcurso;
        }

        // PUT: api/CalendarioConcursos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCalendarioConcurso(int id, CalendarioConcurso calendarioConcurso)
        {
            if (id != calendarioConcurso.CalendarioConcursoId)
            {
                return BadRequest();
            }

            _context.Entry(calendarioConcurso).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CalendarioConcursoExists(id))
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

        // POST: api/CalendarioConcursos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CalendarioConcurso>> PostCalendarioConcurso(CalendarioConcurso calendarioConcurso)
        {
            _context.CalendarioConcurso.Add(calendarioConcurso);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCalendarioConcurso", new { id = calendarioConcurso.CalendarioConcursoId }, calendarioConcurso);
        }

        // DELETE: api/CalendarioConcursos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCalendarioConcurso(int id)
        {
            var calendarioConcurso = await _context.CalendarioConcurso.FindAsync(id);
            if (calendarioConcurso == null)
            {
                return NotFound();
            }

            _context.CalendarioConcurso.Remove(calendarioConcurso);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CalendarioConcursoExists(int id)
        {
            return _context.CalendarioConcurso.Any(e => e.CalendarioConcursoId == id);
        }
    }
}
