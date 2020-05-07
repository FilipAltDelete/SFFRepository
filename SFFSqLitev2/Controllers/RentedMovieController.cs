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
    public class RentedMovieController : ControllerBase
    {
        private readonly SFFContext _context;
        private readonly RentingHandler rentingHandler;

        public RentedMovieController(SFFContext context, RentingHandler renting)
        {
            _context = context;
            rentingHandler = renting;
        }

        // GET: api/RentedMovie
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RentedMovie>>> GetRentedMovies()
        {
            return await _context.RentedMovies.Include(m => m.Movie).Include(s => s.Studio).ToListAsync();
        }

        // GET: api/RentedMovie/5
        [HttpGet("{id}")]
        public async Task<ActionResult<List<RentedMovie>>> GetRentedMovie(int id)
        {
            var rentedMovie = await _context.RentedMovies.Where(s => s.Id == id).Include(a => a.Movie).Include(a => a.Studio).ToListAsync();

            if (rentedMovie == null)
            {
                return NotFound();
            }

            return rentedMovie;
        }



        [HttpGet("{id}/Movies")]
        public async Task<ActionResult<List<RentedMovie>>> GetRentedMoviesFromStudio(int id)
        {
            var rentedMovie = await _context.RentedMovies.Where(s => s.StudioId == id).Include(a => a.Movie).Include(a => a.Studio).ToListAsync();

            if (rentedMovie == null)
            {
                return NotFound();
            }

            return rentedMovie;
        }



        // GET: http://localhost:5000/api/RentedMovie/Etikett/movieId/2/studioId/2
        [HttpGet("Etikett/movieId/{movieId}/studioId/{studioId}")]
        [Produces("application/xml")]
        public async Task<ActionResult<Etikett>> GetEtikett(int movieId, int studioId)
        {

            var movie = await _context.Movies.Where(m => m.Id == movieId).FirstAsync();
            var studio = await _context.Studios.Where(s => s.Id == studioId).FirstAsync();

            if (movie == null)
            {
                return NotFound();
            }
            if (studio == null)
            {
                return NotFound();
            }

            var etikett = rentingHandler.ReturnEtikett(movie, studio);

            return etikett;
        }


        // PUT: api/RentedMovie/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRentedMovie(int id, RentedMovie rentedMovie)
        {
            if (id != rentedMovie.Id)
            {
                return BadRequest();
            }

            _context.Entry(rentedMovie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RentedMovieExists(id))
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


        // POST: api/RentedMovie
        [HttpPost]
        public async Task<ActionResult<RentedMovie>> PostRentedMovie(RentedMovie rentedMovie)
        {
            /*
            rentedMovie.MovieId = Convert.ToInt32(rentedMovie.MovieId);
            rentedMovie.StudioId = Convert.ToInt32(rentedMovie.StudioId);
            */
            var movie = _context.Movies.Where(i => i.Id == rentedMovie.MovieId).First();
            _context.RentedMovies.Add(rentedMovie);
            await _context.SaveChangesAsync();

            List<RentedMovie> rentedMovies = await _context.RentedMovies.ToListAsync();
            bool rentedExtended = rentingHandler.MovieRentingLimiter(rentedMovies, rentedMovie, movie);

            if (rentedExtended == false)
            {
                _context.RentedMovies.Remove(rentedMovie);
                await _context.SaveChangesAsync();
                throw new Exception("DENIED!!!!");

            }

            var rentReciept = _context.RentedMovies.Include(i => i.Movie).Include(i => i.Studio).OrderByDescending(i => i.Id).First();
            string reciept = "Studio: " + rentReciept.Studio.Name + "\nCity: " + rentReciept.Studio.City + "\nRented movie: " + rentReciept.Movie.Title + "\nDate: " + DateTime.Now;
            Console.WriteLine(reciept);

            return null; //CreatedAtAction("GetRentedMovie", new { id = rentedMovie.Id }, rentedMovie);
        }

        // DELETE: api/RentedMovie/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RentedMovie>> ReturnRentedMovie(int id)
        {
            var rentedMovie = _context.RentedMovies.Where(i => i.Id == id).First();

            if (rentedMovie == null)
            {
                return NotFound();
            }

            _context.RentedMovies.Remove(rentedMovie);
            await _context.SaveChangesAsync();

            return rentedMovie;
        }
        // skitmetoder osv...
        [HttpDelete("{id}/grade/{gradeValue}/comment/{commentString}")]
        public async Task<ActionResult<RentedMovie>> ReturnRentedMovie(int id, int gradeValue, string commentString)
        {
            var rentedMovie = _context.RentedMovies.Where(i => i.Id == id).First();
            var movieReview = rentingHandler.ReviewRentedMovie(gradeValue, commentString, rentedMovie);

            if (rentedMovie == null)
            {
                return NotFound();
            }

            _context.Reviews.Add(movieReview);
            _context.RentedMovies.Remove(rentedMovie);
            await _context.SaveChangesAsync();

            return rentedMovie;
        }

        //Skickar deletar en film, sätter betyg och trivia
        [HttpDelete("{id}/grade/{gradeValue}/comment/{commentString}/trivia/{triviaString}")]
        public async Task<ActionResult<RentedMovie>> ReturnRentedMovie(int id, int gradeValue, string commentString, string triviaString)
        {
            var rentedMovie = _context.RentedMovies.Where(i => i.Id == id).First();
            var movieReview = rentingHandler.ReviewRentedMovie(gradeValue, commentString, rentedMovie);
            var movieTrivia = rentingHandler.AddTrivia(triviaString, rentedMovie);

            if (rentedMovie == null)
            {
                return NotFound();
            }

            _context.Reviews.Add(movieReview);
            _context.Trivias.Add(movieTrivia);
            _context.RentedMovies.Remove(rentedMovie);
            await _context.SaveChangesAsync();

            return rentedMovie;
        }

        private bool RentedMovieExists(int id)
        {
            return _context.RentedMovies.Any(e => e.Id == id);
        }
    }
}
