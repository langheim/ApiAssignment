using API_Assignment_3.Models.Domain;
using API_Assignment_3.Models.DTO;
using AutoMapper;
using System.Linq;

namespace API_Assignment_3.Profiles
{
    public class CharacterProfile : Profile
    {
        public CharacterProfile()
        {
            // Create a map for Character to CharacterReadDTO and sending it to an Array
            CreateMap<Character, CharacterReadDTO>().ForMember(cdto => cdto.Movies, opt => opt.MapFrom(c => c.Movies.Select(c => c.Id).ToArray()));
            // Create map for CharacterCreateDTO to Character
            CreateMap<CharacterCreateDTO, Character>();
            // Create map for CharacterEditDTO to Character
            CreateMap<CharacterEditDTO, Character>();
        }
    }
}
