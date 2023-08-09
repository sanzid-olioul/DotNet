using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieRecord.Models;

namespace MovieRecord.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly Context _dbcontext;
        public MoviesController(Context dbcontext)
        {
            _dbcontext = dbcontext;
        }
        //GET: api/Movies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovies()
        {
            if (_dbcontext.Movies == null)
            {
                return NotFound();
            }
            return await _dbcontext.Movies.ToListAsync();
        }

        //GET: api/Movies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovie(int id)
        {
            if (_dbcontext.Movies == null)
            {
                return NotFound();
            }
            var movie = await _dbcontext.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            return movie;
        }

        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie(Movie movie)
        {
            _dbcontext.Movies.Add(movie);
            await _dbcontext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetMovie), new { id = movie.Id }, movie);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutMovie(int id,Movie movie)
        {
            if(id != movie.Id)
            {
                return BadRequest();
            }
            _dbcontext.Entry(movie).State = EntityState.Modified;
            try
            {
                await _dbcontext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(id))
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
        



        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMovie(int id)
        {
            if(_dbcontext.Movies == null)
            {
                return NotFound();
            }
            var movie = await _dbcontext.Movies.FindAsync(id);
            if(movie == null)
            {
                return NotFound();
            }
            _dbcontext.Movies.Remove(movie);
            await _dbcontext.SaveChangesAsync();
            return NoContent();
        }
        private bool MovieExists(int id)
        {
            return (_dbcontext.Movies?.Any(e => e.Id == id)).GetValueOrDefault();
        }

    }
}
