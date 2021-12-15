using API_Assignment_3.Models;
using API_Assignment_3.Models.Domain;
using API_Assignment_3.Models.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Assignment_3.Services
{
    public class FranchiseService : ControllerBase
    {
        private readonly MediaDbContext _context;

        public FranchiseService(MediaDbContext context)
        {
            _context = context;
        }
        // Moved the MovieFranchiseUpdates to services to clean up dbcontext code in main Franchise controller
        public async Task<IActionResult> MovieFranchiseUpdates(int id, List<int> movies)
        {
            // Get list of movies based on franchise ID
            Franchise movieGet = await _context.Franchises.Include(c => c.Movies).Where(c => c.Id == id).FirstAsync();
            // Foreach on all movies
            foreach (int movId in movies)
            {
                Movie movieList = await _context.Movies.FindAsync(movId);
                if (movieList == null)
                    return BadRequest("No movie exist");
                // if movie is not in franchise then add
                if (!movieGet.Movies.Contains(movieList))
                {
                    movieGet.Movies.Add(movieList);
                }
            }
            // Try to update
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
    }
}
