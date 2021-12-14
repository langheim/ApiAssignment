using API_Assignment_3.Models;
using API_Assignment_3.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Assignment_3.Services
{
    public class FranchiseService
    {
        private readonly MediaDbContext _context;

        public FranchiseService(MediaDbContext context)
        {
            _context = context;
        }
        // Moved the MovieFranchiseUpdates to services to clean up dbcontext code in main Franchise controller
        public async Task MovieFranchiseUpdates(int id, List<int> movies)
        {
            // Get list of movies based on ID
            Franchise movieGet = await _context.Franchises.Include(c => c.Movies).Where(c => c.Id == id).FirstAsync();
            // Add new movie List
            List<Movie> moviesList = new();
            // Foreach on all movies
            foreach (int movId in movies)
            {
                Movie movieList = await _context.Movies.FindAsync(movId);
                if (movieList == null) continue;

                moviesList.Add(movieList);
            }
            // set found movies to moviesList
            movieGet.Movies = moviesList;

            //Update changes and return
            await _context.SaveChangesAsync();
        }


    }
}
