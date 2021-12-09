using API_Assignment_3.Models;
using API_Assignment_3.Models.Domain;
using API_Assignment_3.Models.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace API_Assignment_3.Controllers
{
    [Route("api/v1/franchise")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class FranchiseController : ControllerBase
    {
        private readonly MediaDbContext _context;
        private readonly IMapper _mapper;

        public FranchiseController(MediaDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all franchises
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FranchiseReadDTO>>> GetFranchises()
        {
            return _mapper.Map<List<FranchiseReadDTO>>(await _context.Franchises.ToListAsync());
        }

        /// <summary>
        /// Get franchise by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<FranchiseReadDTO>> GetFranchise(int id)
        {
            var franchise = await _context.Franchises.FindAsync(id);

            if (franchise == null)
            {
                return NotFound();
            }

            return _mapper.Map<FranchiseReadDTO>(franchise);
        }

        /// <summary>
        /// Get all movies by franchice ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}/movies")]
        public async Task<ActionResult<FranchiseMovieDTO>> GetMoviesByFranchise(int id)
        {
            var franchise = await _context.Franchises.FindAsync(id);

            if (franchise == null)
            {
                return NotFound();
            }
            await _context.Entry(franchise).Collection(c => c.Movies).LoadAsync();
            return _mapper.Map<FranchiseMovieDTO>(franchise);

        }

        /// <summary>
        /// Get all characters by franchice ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}/characters")]
        public async Task<ActionResult<FranchiseCharactersDTO>> GetCharacterByFranchise(int id)
        {
            var movie = await _context.Movies.Where(c => c.FranchiseId == id).FirstAsync();

            await _context.Entry(movie).Collection(i => i.Characters).LoadAsync();

            return _mapper.Map<FranchiseCharactersDTO>(movie);
        }

        /// <summary>
        /// Update a franchise by ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="franchise"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFranchise(int id, FranchiseReadDTO franchise)
        {
            if (id != franchise.Id)
            {
                return BadRequest();
            }

            Franchise franc = _mapper.Map<Franchise>(franchise);
            _context.Entry(franc).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FranchiseExists(id))
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
        /// Update movie in franchice
        /// </summary>
        /// <param name="id"></param>
        /// <param name="movies"></param>
        /// <returns></returns>
        [HttpPut("{id}/movieUpdate")]
        public async Task<IActionResult> MovieFranchiseUpdate(int id, List<int> movies)
        {
            if (!FranchiseExists(id))
            {
                return NotFound();
            }

            Franchise movieGet = await _context.Franchises
                .Include(c => c.Movies)
                .Where(c => c.Id == id)
                .FirstAsync();

            List<Movie> moviesList = new();
            foreach (int movId in movies)
            {
                Movie movieList = await _context.Movies.FindAsync(movId);
                if (movieList == null)
                    return BadRequest("No movie found with this ID!");
                moviesList.Add(movieList);
            }
            movieGet.Movies = moviesList;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

        /// <summary>
        /// Add a new franchise
        /// </summary>
        /// <param name="franchise"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<FranchiseCreateDTO>> PostFranchise(FranchiseCreateDTO franchise)
        {
            Franchise addFranchise = _mapper.Map<Franchise>(franchise);
            _context.Franchises.Add(addFranchise);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFranchise", new { id = addFranchise.Id }, franchise);
        }

        /// <summary>
        /// Delete a franchise by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFranchise(int id)
        {
            var franchise = await _context.Franchises.FindAsync(id);
            if (franchise == null)
            {
                return NotFound();
            }

            _context.Franchises.Remove(franchise);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FranchiseExists(int id)
        {
            return _context.Franchises.Any(e => e.Id == id);
        }
    }
}
