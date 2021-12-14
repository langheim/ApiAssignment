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
    [Route("api/v1/character")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class CharacterController : ControllerBase
    {
        // link to DbContext
        private readonly MediaDbContext _context;
        // Add automapper
        private readonly IMapper _mapper;

        public CharacterController(MediaDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Returns a list of all characters
        /// </summary>
        /// <returns>Returns a list of all characters and movies they are in</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CharacterReadDTO>>> GetCharacters()
        {
            // get list from dbcontext and automap
            return _mapper.Map<List<CharacterReadDTO>>(await _context.Characters.Include(c => c.Movies).ToListAsync());
        }

        /// <summary>
        /// Get character by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns a character based on ID with movies they are in, throws 404 Not found if character does not exist</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<CharacterReadDTO>> GetCharacter(int id)
        {
            // get list from dbcontext
            var character = await _context.Characters.FindAsync(id);
            // Check if not null
            if (character == null)
            {
                return NotFound();
            }
            // get movie from dbContext
            await _context.Entry(character).Collection(i => i.Movies).LoadAsync();
            // Return character
            return _mapper.Map<CharacterReadDTO>(character);

        }

        /// <summary>
        /// Update a character by ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="character"></param>
        /// <returns>Updates a character based on input ID, throws Bad request if ID is not equal to ID, throws 404 Not found if character does not exist</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCharacter(int id, CharacterEditDTO character)
        {
            // Check if character ID input is equal to ID
            if (id != character.Id)
            {
                return BadRequest();
            }
            // Set input layout
            Character chars = _mapper.Map<Character>(character);
            _context.Entry(chars).State = EntityState.Modified;
            // Try to update
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CharacterExists(id))
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
        /// Add a new character
        /// </summary>
        /// <param name="character"></param>
        /// <returns>Returns new character created with automapper field defined in CharacterReadDTO</returns>
        [HttpPost]
        public async Task<ActionResult<Character>> PostCharacter(CharacterCreateDTO character)
        {
            // Set input layout
            Character characterAdd = _mapper.Map<Character>(character);
            // Add return
            _context.Characters.Add(characterAdd);
            // Update
            await _context.SaveChangesAsync();
            // Return
            return CreatedAtAction("GetCharacter", new { id = characterAdd.Id }, _mapper.Map<CharacterReadDTO>(characterAdd));
        }

        /// <summary>
        /// Delete a character by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Deletes a character based on ID supplied, throws 404 Not found if character does not exist</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharacter(int id)
        {
            // Set character from return of dbcontext
            var character = await _context.Characters.FindAsync(id);
            // Check if not null
            if (character == null)
            {
                return NotFound();
            }
            // Remove
            _context.Characters.Remove(character);
            // Update
            await _context.SaveChangesAsync();
            return NoContent();
        }
        // Check that Character exists
        private bool CharacterExists(int id)
        {
            return _context.Characters.Any(e => e.Id == id);
        }
    }
}
