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
    public class RedacaosController : ControllerBase
    {
        private readonly GabaritaContext _context;

        public RedacaosController(GabaritaContext context)
        {
            _context = context;
        }

        // GET: api/Redacaos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Redacao>>> GetRedacao()
        {
            return await _context.Redacao.ToListAsync();
        }

        // GET: api/Redacaos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Redacao>> GetRedacao(Guid id)
        {
            var redacao = await _context.Redacao.FindAsync(id);

            if (redacao == null)
            {
                return NotFound();
            }

            return redacao;
        }

        // PUT: api/Redacaos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRedacao(Guid id, Redacao redacao)
        {
            if (id != redacao.RedacaoId)
            {
                return BadRequest();
            }

            _context.Entry(redacao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RedacaoExists(id))
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

        // POST: api/Redacaos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Redacao>> PostRedacao(Redacao redacao)
        {
            _context.Redacao.Add(redacao);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRedacao", new { id = redacao.RedacaoId }, redacao);
        }

        // DELETE: api/Redacaos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRedacao(Guid id)
        {
            var redacao = await _context.Redacao.FindAsync(id);
            if (redacao == null)
            {
                return NotFound();
            }

            _context.Redacao.Remove(redacao);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RedacaoExists(Guid id)
        {
            return _context.Redacao.Any(e => e.RedacaoId == id);
        }
    }
}
