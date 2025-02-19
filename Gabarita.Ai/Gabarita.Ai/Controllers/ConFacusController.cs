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
    public class ConFacusController : ControllerBase
    {
        private readonly GabaritaContext _context;

        public ConFacusController(GabaritaContext context)
        {
            _context = context;
        }

        // GET: api/ConFacus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConFacu>>> GetConFacu()
        {
            return await _context.ConFacu.ToListAsync();
        }

        // GET: api/ConFacus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ConFacu>> GetConFacu(int id)
        {
            var conFacu = await _context.ConFacu.FindAsync(id);

            if (conFacu == null)
            {
                return NotFound();
            }

            return conFacu;
        }

        // PUT: api/ConFacus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConFacu(int id, ConFacu conFacu)
        {
            if (id != conFacu.ConFacuId)
            {
                return BadRequest();
            }

            _context.Entry(conFacu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConFacuExists(id))
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

        // POST: api/ConFacus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ConFacu>> PostConFacu(ConFacu conFacu)
        {
            _context.ConFacu.Add(conFacu);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConFacu", new { id = conFacu.ConFacuId }, conFacu);
        }

        // DELETE: api/ConFacus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConFacu(int id)
        {
            var conFacu = await _context.ConFacu.FindAsync(id);
            if (conFacu == null)
            {
                return NotFound();
            }

            _context.ConFacu.Remove(conFacu);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ConFacuExists(int id)
        {
            return _context.ConFacu.Any(e => e.ConFacuId == id);
        }
    }
}
