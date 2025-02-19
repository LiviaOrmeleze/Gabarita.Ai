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
    public class ConteudoEscolhidosController : ControllerBase
    {
        private readonly GabaritaContext _context;

        public ConteudoEscolhidosController(GabaritaContext context)
        {
            _context = context;
        }

        // GET: api/ConteudoEscolhidos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConteudoEscolhido>>> GetConteudoEscolhido()
        {
            return await _context.ConteudoEscolhido.ToListAsync();
        }

        // GET: api/ConteudoEscolhidos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ConteudoEscolhido>> GetConteudoEscolhido(int id)
        {
            var conteudoEscolhido = await _context.ConteudoEscolhido.FindAsync(id);

            if (conteudoEscolhido == null)
            {
                return NotFound();
            }

            return conteudoEscolhido;
        }

        // PUT: api/ConteudoEscolhidos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConteudoEscolhido(int id, ConteudoEscolhido conteudoEscolhido)
        {
            if (id != conteudoEscolhido.Id)
            {
                return BadRequest();
            }

            _context.Entry(conteudoEscolhido).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConteudoEscolhidoExists(id))
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

        // POST: api/ConteudoEscolhidos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ConteudoEscolhido>> PostConteudoEscolhido(ConteudoEscolhido conteudoEscolhido)
        {
            _context.ConteudoEscolhido.Add(conteudoEscolhido);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConteudoEscolhido", new { id = conteudoEscolhido.Id }, conteudoEscolhido);
        }

        // DELETE: api/ConteudoEscolhidos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConteudoEscolhido(int id)
        {
            var conteudoEscolhido = await _context.ConteudoEscolhido.FindAsync(id);
            if (conteudoEscolhido == null)
            {
                return NotFound();
            }

            _context.ConteudoEscolhido.Remove(conteudoEscolhido);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ConteudoEscolhidoExists(int id)
        {
            return _context.ConteudoEscolhido.Any(e => e.Id == id);
        }
    }
}
