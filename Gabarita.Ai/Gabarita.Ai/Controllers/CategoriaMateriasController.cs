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
    public class CategoriaMateriasController : ControllerBase
    {
        private readonly GabaritaContext _context;

        public CategoriaMateriasController(GabaritaContext context)
        {
            _context = context;
        }

        // GET: api/CategoriaMaterias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriaMateria>>> GetCategoriaMateria()
        {
            return await _context.CategoriaMateria.ToListAsync();
        }

        // GET: api/CategoriaMaterias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoriaMateria>> GetCategoriaMateria(Guid id)
        {
            var categoriaMateria = await _context.CategoriaMateria.FindAsync(id);

            if (categoriaMateria == null)
            {
                return NotFound();
            }

            return categoriaMateria;
        }

        // PUT: api/CategoriaMaterias/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoriaMateria(Guid id, CategoriaMateria categoriaMateria)
        {
            if (id != categoriaMateria.CategoriaMateriaId)
            {
                return BadRequest();
            }

            _context.Entry(categoriaMateria).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoriaMateriaExists(id))
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

        // POST: api/CategoriaMaterias
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CategoriaMateria>> PostCategoriaMateria(CategoriaMateria categoriaMateria)
        {
            _context.CategoriaMateria.Add(categoriaMateria);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategoriaMateria", new { id = categoriaMateria.CategoriaMateriaId }, categoriaMateria);
        }

        // DELETE: api/CategoriaMaterias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoriaMateria(Guid id)
        {
            var categoriaMateria = await _context.CategoriaMateria.FindAsync(id);
            if (categoriaMateria == null)
            {
                return NotFound();
            }

            _context.CategoriaMateria.Remove(categoriaMateria);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CategoriaMateriaExists(Guid id)
        {
            return _context.CategoriaMateria.Any(e => e.CategoriaMateriaId == id);
        }
    }
}
