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
    public class ConteudosController : ControllerBase
    {
        private readonly GabaritaContext _context;

        public ConteudosController(GabaritaContext context)
        {
            _context = context;
        }

        // GET: api/Conteudos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Conteudo>>> GetConteudo()
        {
            return await _context.Conteudo.ToListAsync();
        }

        // GET: api/Conteudos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Conteudo>> GetConteudo(Guid id)
        {
            var conteudo = await _context.Conteudo.FindAsync(id);

            if (conteudo == null)
            {
                return NotFound();
            }

            return conteudo;
        }

        // PUT: api/Conteudos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConteudo(Guid id, Conteudo conteudo)
        {
            if (id != conteudo.ConteudoId)
            {
                return BadRequest();
            }

            _context.Entry(conteudo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConteudoExists(id))
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

        // POST: api/Conteudos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Conteudo>> PostConteudo(Conteudo conteudo)
        {
            _context.Conteudo.Add(conteudo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConteudo", new { id = conteudo.ConteudoId }, conteudo);
        }

        // DELETE: api/Conteudos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConteudo(Guid id)
        {
            var conteudo = await _context.Conteudo.FindAsync(id);
            if (conteudo == null)
            {
                return NotFound();
            }

            _context.Conteudo.Remove(conteudo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ConteudoExists(Guid id)
        {
            return _context.Conteudo.Any(e => e.ConteudoId == id);
        }
    }
}
