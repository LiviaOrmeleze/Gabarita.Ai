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
    public class QuestionariosController : ControllerBase
    {
        private readonly GabaritaContext _context;

        public QuestionariosController(GabaritaContext context)
        {
            _context = context;
        }

        // GET: api/Questionarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Questionario>>> GetQuestionario()
        {
            return await _context.Questionario.ToListAsync();
        }

        // GET: api/Questionarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Questionario>> GetQuestionario(Guid id)
        {
            var questionario = await _context.Questionario.FindAsync(id);

            if (questionario == null)
            {
                return NotFound();
            }

            return questionario;
        }

        // PUT: api/Questionarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuestionario(Guid id, Questionario questionario)
        {
            if (id != questionario.QuestionarioId)
            {
                return BadRequest();
            }

            _context.Entry(questionario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuestionarioExists(id))
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

        // POST: api/Questionarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Questionario>> PostQuestionario(Questionario questionario)
        {
            _context.Questionario.Add(questionario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuestionario", new { id = questionario.QuestionarioId }, questionario);
        }

        // DELETE: api/Questionarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestionario(Guid id)
        {
            var questionario = await _context.Questionario.FindAsync(id);
            if (questionario == null)
            {
                return NotFound();
            }

            _context.Questionario.Remove(questionario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool QuestionarioExists(Guid id)
        {
            return _context.Questionario.Any(e => e.QuestionarioId == id);
        }
    }
}
