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
    public class TipoConteudosController : ControllerBase
    {
        private readonly GabaritaContext _context;

        public TipoConteudosController(GabaritaContext context)
        {
            _context = context;
        }

        // GET: api/TipoConteudos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoConteudo>>> GetTipoConteudo()
        {
            return await _context.TipoConteudo.ToListAsync();
        }

        // GET: api/TipoConteudos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoConteudo>> GetTipoConteudo(Guid id)
        {
            var tipoConteudo = await _context.TipoConteudo.FindAsync(id);

            if (tipoConteudo == null)
            {
                return NotFound();
            }

            return tipoConteudo;
        }

        // PUT: api/TipoConteudos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoConteudo(Guid id, TipoConteudo tipoConteudo)
        {
            if (id != tipoConteudo.TipoConteudoId)
            {
                return BadRequest();
            }

            _context.Entry(tipoConteudo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoConteudoExists(id))
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

        // POST: api/TipoConteudos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TipoConteudo>> PostTipoConteudo(TipoConteudo tipoConteudo)
        {
            _context.TipoConteudo.Add(tipoConteudo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoConteudo", new { id = tipoConteudo.TipoConteudoId }, tipoConteudo);
        }

        // DELETE: api/TipoConteudos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoConteudo(Guid id)
        {
            var tipoConteudo = await _context.TipoConteudo.FindAsync(id);
            if (tipoConteudo == null)
            {
                return NotFound();
            }

            _context.TipoConteudo.Remove(tipoConteudo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoConteudoExists(Guid id)
        {
            return _context.TipoConteudo.Any(e => e.TipoConteudoId == id);
        }
    }
}
