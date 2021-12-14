using API_Assignment_3.Models;
using API_Assignment_3.Models.Domain;
using API_Assignment_3.Models.DTO;
using API_Assignment_3.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace API_Assignment_3.Controllers
{
    [Route("api/v1/movie")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class MovieController : ControllerBase
    {
        // link to DbContext
        private readonly MediaDbContext _context;
        // injecting services
        private readonly MovieService _movieService;
        private readonly IMapper _mapper;

        public MovieController(MediaDbContext context, IMapper mapper, MovieService movieService)
        {
            _context = context;
            _mapper = mapper;
            _movieService = movieService;
        }

        /// <summary>
        /// Get all movies
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieReadDTO>>> GetMovies()
        {
            return _mapper.Map<List<MovieReadDTO>>(await _context.Movies.ToListAsync());
        }

        /// <summary>
        /// Get movie by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<MovieReadDTO>> GetMovie(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            // Check if movie ID exists
            if (movie == null)
            {
                return NotFound();
            }

            return _mapper.Map<MovieReadDTO>(movie);
        }

        /// <summary>
        /// Get all characters in a movie by movie ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}/characters")]
        public async Task<ActionResult<MovieCharactersDTO>> GetMoviesWithCharacter(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            // Check if movie ID exists
            if (movie == null)
            {
                return NotFound();
            }

            await _context.Entry(movie).Collection(c => c.Characters).LoadAsync();
            return _mapper.Map<MovieCharactersDTO>(movie);
        }
        /// <summary>
        /// Update movie by ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="movie"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(int id, MovieEditDTO movie)
        {
            // Check if movie ID exists
            if (id != movie.Id)
            {
                return BadRequest();
            }

            Movie movies = _mapper.Map<Movie>(movie);
            _context.Entry(movies).State = EntityState.Modified;
            // Try to update
            try
            {
                await _context.SaveChangesAsync();
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
        /// <summary>
        /// Update character in a movie
        /// </summary>
        /// <param name="id"></param>
        /// <param name="characters"></param>
        /// <returns></returns>
        [HttpPut("{id}/characterUpdate")]
        public async Task<IActionResult> UpdateCharactersInMovie(int id, List<int> characters)
        {
            // Check if movie ID exists
            if (!MovieExists(id))
            {
                return NotFound();
            }
            // try to update
            try
            {
                await _movieService.UpdateCharacterInMovie(id, characters);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
            return NoContent();
        }

        /// <summary>
        /// Add a new movie
        /// </summary>
        /// <param name="movie"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie(MovieCreateDTO movie)
        {
            Movie movies = _mapper.Map<Movie>(movie);
            _context.Movies.Add(movies);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMovie", new { id = movies.Id }, movie);
        }

        /// <summary>
        /// Delete a movie by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MovieExists(int id)
        {
            return _context.Movies.Any(e => e.Id == id);
        }
    }
}
