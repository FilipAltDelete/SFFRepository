using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SFFSqLite.Models;

namespace SFFSqLite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TriviaController : ControllerBase
    {
        private readonly SFFContext _context;

        public TriviaController(SFFContext context)
        {
            _context = context;
        }

        // GET: api/Trivia
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Trivia>>> GetTrivia()
        {
            return await _context.Trivias.Include(m => m.Movie).ToListAsync();
        }

        // GET: api/Trivia/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Trivia>> GetTrivia(int id)
        {
            var trivia = await _context.Trivias.Include(m => m.Movie).Where(r => r.Id == id).FirstAsync();

            if (trivia == null)
            {
                return NotFound();
            }

            return trivia;
        }


        [HttpGet("{id}/Trivias")]
        public async Task<ActionResult<IEnumerable<Trivia>>> GetTriviaWithSameMovie(int id)
        {
            var trivias = await _context.Trivias.Where(r => r.MovieId == id).Include(a => a.Movie).ToListAsync();

            if (trivias == null)
            {
                return NotFound();
            }

            return trivias;
        }

        // PUT: api/Trivia/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrivia(int id, Trivia trivia)
        {
            if (id != trivia.Id)
            {
                return BadRequest();
            }

            _context.Entry(trivia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TriviaExists(id))
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

        // POST: api/Trivia
        [HttpPost]
        public async Task<ActionResult<Trivia>> PostTrivia(Trivia trivia)
        {

            _context.Trivias.Add(trivia);
            await _context.SaveChangesAsync();

            return null; //CreatedAtAction("GetTrivia", new { id = trivia.Id }, trivia);
        }

        // DELETE: api/Trivia/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Trivia>> DeleteTrivia(int id)
        {
            var trivia = await _context.Trivias.FindAsync(id);
            if (trivia == null)
            {
                return NotFound();
            }

            _context.Trivias.Remove(trivia);
            await _context.SaveChangesAsync();

            return trivia;
        }

        private bool TriviaExists(int id)
        {
            return _context.Trivias.Any(e => e.Id == id);
        }
    }
}
