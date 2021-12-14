using API_Assignment_3.Models.Domain;
using API_Assignment_3.Models.DTO;
using AutoMapper;
using System.Linq;

namespace API_Assignment_3.Profiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            // Map Movie to MovieReadDTO
            CreateMap<Movie, MovieReadDTO>();
            // create map for CreateDTO to Movie
            CreateMap<MovieCreateDTO, Movie>();
            // Create map for EditDTO to Movie
            CreateMap<MovieEditDTO, Movie>();
            // Create map for Characters in movies and sending characters to an array
            CreateMap<Movie, MovieCharactersDTO>().ForMember(cdto => cdto.Characters, opt => opt.MapFrom(c => c.Characters.Select(c => c.FullName).ToArray()));
        }
    }
}
