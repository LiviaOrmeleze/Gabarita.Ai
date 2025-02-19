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
    public class FlashCardsController : ControllerBase
    {
        private readonly GabaritaContext _context;

        public FlashCardsController(GabaritaContext context)
        {
            _context = context;
        }

        // GET: api/FlashCards
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FlashCard>>> GetFlashCard()
        {
            return await _context.FlashCard.ToListAsync();
        }

        // GET: api/FlashCards/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FlashCard>> GetFlashCard(int id)
        {
            var flashCard = await _context.FlashCard.FindAsync(id);

            if (flashCard == null)
            {
                return NotFound();
            }

            return flashCard;
        }

        // PUT: api/FlashCards/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFlashCard(int id, FlashCard flashCard)
        {
            if (id != flashCard.FlashCardId)
            {
                return BadRequest();
            }

            _context.Entry(flashCard).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FlashCardExists(id))
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

        // POST: api/FlashCards
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FlashCard>> PostFlashCard(FlashCard flashCard)
        {
            _context.FlashCard.Add(flashCard);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFlashCard", new { id = flashCard.FlashCardId }, flashCard);
        }

        // DELETE: api/FlashCards/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFlashCard(int id)
        {
            var flashCard = await _context.FlashCard.FindAsync(id);
            if (flashCard == null)
            {
                return NotFound();
            }

            _context.FlashCard.Remove(flashCard);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FlashCardExists(int id)
        {
            return _context.FlashCard.Any(e => e.FlashCardId == id);
        }
    }
}
