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
            // Character->CharacterReadDTO
            CreateMap<Character, CharacterReadDTO>()
            // Turning related movies into int arrays
            .ForMember(cdto => cdto.Movies, opt => opt
            .MapFrom(c => c.Movies.Select(c => c.Id).ToArray()));
            // CHaracterCreateDTO->Character
            CreateMap<CharacterCreateDTO, Character>();
            // CharacterEditDTO->Character
            CreateMap<CharacterEditDTO, Character>();
        }
    }
}
