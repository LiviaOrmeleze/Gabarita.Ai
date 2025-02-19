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
    public class CronogramasController : ControllerBase
    {
        private readonly GabaritaContext _context;

        public CronogramasController(GabaritaContext context)
        {
            _context = context;
        }

        // GET: api/Cronogramas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cronograma>>> GetCronograma()
        {
            return await _context.Cronograma.ToListAsync();
        }

        // GET: api/Cronogramas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cronograma>> GetCronograma(Guid id)
        {
            var cronograma = await _context.Cronograma.FindAsync(id);

            if (cronograma == null)
            {
                return NotFound();
            }

            return cronograma;
        }

        // PUT: api/Cronogramas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCronograma(Guid id, Cronograma cronograma)
        {
            if (id != cronograma.CronogramaId)
            {
                return BadRequest();
            }

            _context.Entry(cronograma).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CronogramaExists(id))
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

        // POST: api/Cronogramas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cronograma>> PostCronograma(Cronograma cronograma)
        {
            _context.Cronograma.Add(cronograma);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCronograma", new { id = cronograma.CronogramaId }, cronograma);
        }

        // DELETE: api/Cronogramas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCronograma(Guid id)
        {
            var cronograma = await _context.Cronograma.FindAsync(id);
            if (cronograma == null)
            {
                return NotFound();
            }

            _context.Cronograma.Remove(cronograma);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CronogramaExists(Guid id)
        {
            return _context.Cronograma.Any(e => e.CronogramaId == id);
        }
    }
}
