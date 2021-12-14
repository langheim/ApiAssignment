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
        // Add automapper
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
        /// <returns>Returns a list of all Movies in DB</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieReadDTO>>> GetMovies()
        {
            // get list from dbcontext and automap
            return _mapper.Map<List<MovieReadDTO>>(await _context.Movies.ToListAsync());
        }

        /// <summary>
        /// Get movie by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns a movie based on ID supplied</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<MovieReadDTO>> GetMovie(int id)
        {
            // get list from dbcontext
            var movie = await _context.Movies.FindAsync(id);
            // Check if movie ID exists
            if (movie == null)
            {
                return NotFound();
            }
            // set return to automap
            return _mapper.Map<MovieReadDTO>(movie);
        }

        /// <summary>
        /// Get all characters in a movie by movie ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns movie based on ID and also characters in selected movie</returns>
        [HttpGet("{id}/characters")]
        public async Task<ActionResult<MovieCharactersDTO>> GetMoviesWithCharacter(int id)
        {
            // get list by ID from dbcontext
            var movie = await _context.Movies.FindAsync(id);
            // Check if movie ID exists
            if (movie == null)
            {
                return NotFound();
            }
            // get collection of Characters from dbContext
            await _context.Entry(movie).Collection(c => c.Characters).LoadAsync();
            // set return to automap
            return _mapper.Map<MovieCharactersDTO>(movie);
        }
        /// <summary>
        /// Update movie by ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="movie"></param>
        /// <returns>Update movie based on ID supplied formats via MovieEditDTO</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(int id, MovieEditDTO movie)
        {
            // Check if movie ID exists
            if (id != movie.Id)
            {
                return BadRequest();
            }
            // get list from automapper
            Movie movies = _mapper.Map<Movie>(movie);
            // get list of movies based on modified
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
            // if nothing then return NoContent
            return NoContent();
        }
        /// <summary>
        /// Update character in a movie
        /// </summary>
        /// <param name="id"></param>
        /// <param name="characters"></param>
        /// <returns>Update a character in a movie based on ID supplied from Int List</returns>
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
            // if nothing then return NoContent
            return NoContent();
        }

        /// <summary>
        /// Add a new movie
        /// </summary>
        /// <param name="movie"></param>
        /// <returns>Adds a new movie based on MovieCreateDTO</returns>
        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie(MovieCreateDTO movie)
        {
            // get list of movies from Automapper
            Movie movies = _mapper.Map<Movie>(movie);
            // Add movies to dbcontext 
            _context.Movies.Add(movies);
            // Update the changes 
            await _context.SaveChangesAsync();
            // Return updated post
            return CreatedAtAction("GetMovie", new { id = movies.Id }, movie);
        }

        /// <summary>
        /// Delete a movie by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Deletes a movie based on ID supplied</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            // get list by ID from dbcontext
            var movie = await _context.Movies.FindAsync(id);
            // Check if movie has no value
            if (movie == null)
            {
                return NotFound();
            }
            // remove movie selected from var movie
            _context.Movies.Remove(movie);
            // Update
            await _context.SaveChangesAsync();
            // Return noContent
            return NoContent();
        }

        // Check that Movie exists
        private bool MovieExists(int id)
        {
            return _context.Movies.Any(e => e.Id == id);
        }
    }
}
