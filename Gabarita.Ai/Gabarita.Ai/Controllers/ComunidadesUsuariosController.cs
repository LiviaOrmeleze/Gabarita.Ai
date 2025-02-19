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
    public class ComunidadesUsuariosController : ControllerBase
    {
        private readonly GabaritaContext _context;

        public ComunidadesUsuariosController(GabaritaContext context)
        {
            _context = context;
        }

        // GET: api/ComunidadesUsuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ComunidadesUsuario>>> GetComunidadesUsuario()
        {
            return await _context.ComunidadesUsuario.ToListAsync();
        }

        // GET: api/ComunidadesUsuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ComunidadesUsuario>> GetComunidadesUsuario(Guid id)
        {
            var comunidadesUsuario = await _context.ComunidadesUsuario.FindAsync(id);

            if (comunidadesUsuario == null)
            {
                return NotFound();
            }

            return comunidadesUsuario;
        }

        // PUT: api/ComunidadesUsuarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComunidadesUsuario(Guid id, ComunidadesUsuario comunidadesUsuario)
        {
            if (id != comunidadesUsuario.ComunidadesUsuarioId)
            {
                return BadRequest();
            }

            _context.Entry(comunidadesUsuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComunidadesUsuarioExists(id))
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

        // POST: api/ComunidadesUsuarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ComunidadesUsuario>> PostComunidadesUsuario(ComunidadesUsuario comunidadesUsuario)
        {
            _context.ComunidadesUsuario.Add(comunidadesUsuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetComunidadesUsuario", new { id = comunidadesUsuario.ComunidadesUsuarioId }, comunidadesUsuario);
        }

        // DELETE: api/ComunidadesUsuarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComunidadesUsuario(Guid id)
        {
            var comunidadesUsuario = await _context.ComunidadesUsuario.FindAsync(id);
            if (comunidadesUsuario == null)
            {
                return NotFound();
            }

            _context.ComunidadesUsuario.Remove(comunidadesUsuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ComunidadesUsuarioExists(Guid id)
        {
            return _context.ComunidadesUsuario.Any(e => e.ComunidadesUsuarioId == id);
        }
    }
}
