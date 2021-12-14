using API_Assignment_3.Models;
using API_Assignment_3.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Assignment_3.Services
{
    public class MovieService
    {
        private readonly MediaDbContext _context;
        public MovieService(MediaDbContext context)
        {
            _context = context;
        }

        // Moved the UpdateCharactersInMovie to services to clean up dbcontext code in main controller
        public async Task UpdateCharacterInMovie(int id, List<int> characters)
        {
            // Get a list of characters based on movie ID
            Movie charactersInMovie = await _context.Movies.Include(c => c.Characters).Where(c => c.Id == id).FirstAsync();

            // Check for character id in characters
            foreach (int characterId in characters)
            {
                Character chararcters = await _context.Characters.FindAsync(characterId);
                if (characters == null)
                    continue;
                if (charactersInMovie.Characters.Contains(chararcters))
                    continue;
                // Add character
                charactersInMovie.Characters.Add(chararcters);
            }
            //Update changes and return
            await _context.SaveChangesAsync();

        }
    }
}
