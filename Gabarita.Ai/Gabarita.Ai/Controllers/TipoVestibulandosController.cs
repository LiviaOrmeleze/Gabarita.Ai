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
    public class TipoVestibulandosController : ControllerBase
    {
        private readonly GabaritaContext _context;

        public TipoVestibulandosController(GabaritaContext context)
        {
            _context = context;
        }

        // GET: api/TipoVestibulandos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoVestibulando>>> GetTipoVestibulando()
        {
            return await _context.TipoVestibulando.ToListAsync();
        }

        // GET: api/TipoVestibulandos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoVestibulando>> GetTipoVestibulando(Guid id)
        {
            var tipoVestibulando = await _context.TipoVestibulando.FindAsync(id);

            if (tipoVestibulando == null)
            {
                return NotFound();
            }

            return tipoVestibulando;
        }

        // PUT: api/TipoVestibulandos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoVestibulando(Guid id, TipoVestibulando tipoVestibulando)
        {
            if (id != tipoVestibulando.TipoVestibulandoId)
            {
                return BadRequest();
            }

            _context.Entry(tipoVestibulando).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoVestibulandoExists(id))
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

        // POST: api/TipoVestibulandos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TipoVestibulando>> PostTipoVestibulando(TipoVestibulando tipoVestibulando)
        {
            _context.TipoVestibulando.Add(tipoVestibulando);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoVestibulando", new { id = tipoVestibulando.TipoVestibulandoId }, tipoVestibulando);
        }

        // DELETE: api/TipoVestibulandos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoVestibulando(Guid id)
        {
            var tipoVestibulando = await _context.TipoVestibulando.FindAsync(id);
            if (tipoVestibulando == null)
            {
                return NotFound();
            }

            _context.TipoVestibulando.Remove(tipoVestibulando);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoVestibulandoExists(Guid id)
        {
            return _context.TipoVestibulando.Any(e => e.TipoVestibulandoId == id);
        }
    }
}
