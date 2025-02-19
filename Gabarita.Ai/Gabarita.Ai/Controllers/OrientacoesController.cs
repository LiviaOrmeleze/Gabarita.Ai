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
    public class OrientacoesController : ControllerBase
    {
        private readonly GabaritaContext _context;

        public OrientacoesController(GabaritaContext context)
        {
            _context = context;
        }

        // GET: api/Orientacoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Orientacoes>>> GetOrientacoes()
        {
            return await _context.Orientacoes.ToListAsync();
        }

        // GET: api/Orientacoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Orientacoes>> GetOrientacoes(Guid id)
        {
            var orientacoes = await _context.Orientacoes.FindAsync(id);

            if (orientacoes == null)
            {
                return NotFound();
            }

            return orientacoes;
        }

        // PUT: api/Orientacoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrientacoes(Guid id, Orientacoes orientacoes)
        {
            if (id != orientacoes.OrientacoesId)
            {
                return BadRequest();
            }

            _context.Entry(orientacoes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrientacoesExists(id))
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

        // POST: api/Orientacoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Orientacoes>> PostOrientacoes(Orientacoes orientacoes)
        {
            _context.Orientacoes.Add(orientacoes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrientacoes", new { id = orientacoes.OrientacoesId }, orientacoes);
        }

        // DELETE: api/Orientacoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrientacoes(Guid id)
        {
            var orientacoes = await _context.Orientacoes.FindAsync(id);
            if (orientacoes == null)
            {
                return NotFound();
            }

            _context.Orientacoes.Remove(orientacoes);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrientacoesExists(Guid id)
        {
            return _context.Orientacoes.Any(e => e.OrientacoesId == id);
        }
    }
}
