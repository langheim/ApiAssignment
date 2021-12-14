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
    [Route("api/v1/franchise")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class FranchiseController : ControllerBase
    {
        // link to DbContext
        private readonly MediaDbContext _context;
        // injecting services
        private readonly FranchiseService _franchiseService;
        private readonly IMapper _mapper;

        public FranchiseController(MediaDbContext context, IMapper mapper, FranchiseService franchiseService)
        {
            _context = context;
            _franchiseService = franchiseService;
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
            // Check if if exists
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
            // Check if exists
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
            // return a not found if id is 1 since 1 is default No franchise id
            if (id == 1)
            {
                return NotFound();
            }
            // Check if franchiseID is valid
            if (!FranchiseExists(id))
            {
                return NotFound();
            }
            else
            {
                var movie = await _context.Movies.Where(c => c.FranchiseId == id).FirstAsync();
               
                await _context.Entry(movie).Collection(i => i.Characters).LoadAsync();
                return _mapper.Map<FranchiseCharactersDTO>(movie);
            }
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
            // Check franchise ID
            if (id != franchise.Id)
            {
                return BadRequest();
            }

            Franchise franc = _mapper.Map<Franchise>(franchise);
            _context.Entry(franc).State = EntityState.Modified;

            // Try to update
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
            // Check if ID is valid
            if (id <= 0 || movies.Count == 0)
            {
                return BadRequest("Invalid ID");
            }
            // Test if update is possible
            try
            {
                await _franchiseService.MovieFranchiseUpdates(id, movies);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
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
            // Check if exists
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
