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
    public class ResumosController : ControllerBase
    {
        private readonly GabaritaContext _context;

        public ResumosController(GabaritaContext context)
        {
            _context = context;
        }

        // GET: api/Resumos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Resumo>>> GetResumo()
        {
            return await _context.Resumo.ToListAsync();
        }

        // GET: api/Resumos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Resumo>> GetResumo(Guid id)
        {
            var resumo = await _context.Resumo.FindAsync(id);

            if (resumo == null)
            {
                return NotFound();
            }

            return resumo;
        }

        // PUT: api/Resumos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutResumo(Guid id, Resumo resumo)
        {
            if (id != resumo.ResumoId)
            {
                return BadRequest();
            }

            _context.Entry(resumo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResumoExists(id))
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

        // POST: api/Resumos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Resumo>> PostResumo(Resumo resumo)
        {
            _context.Resumo.Add(resumo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetResumo", new { id = resumo.ResumoId }, resumo);
        }

        // DELETE: api/Resumos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResumo(Guid id)
        {
            var resumo = await _context.Resumo.FindAsync(id);
            if (resumo == null)
            {
                return NotFound();
            }

            _context.Resumo.Remove(resumo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ResumoExists(Guid id)
        {
            return _context.Resumo.Any(e => e.ResumoId == id);
        }
    }
}
