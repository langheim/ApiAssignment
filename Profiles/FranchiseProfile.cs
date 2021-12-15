using API_Assignment_3.Models.Domain;
using API_Assignment_3.Models.DTO;
using AutoMapper;
using System.Linq;

namespace API_Assignment_3.Profiles
{
    public class FranchiseProfile : Profile
    {
        public FranchiseProfile()
        {
            // Create map for Franchise to ReadDTO
            CreateMap<Franchise, FranchiseReadDTO>().ReverseMap();
            // Create map for Franchise to CreateDTO
            CreateMap<Franchise, FranchiseCreateDTO>().ReverseMap();
            // Create map for Franchise to FranchiseMovieDTO and sending title to an array
            CreateMap<Franchise, FranchiseMovieDTO>().ForMember(fmdto => fmdto.Movies, opt => opt.MapFrom(c => c.Movies.Select(c => c.Title).ToArray()));
            // Create map for Characters in movies and sending full name to an array
            CreateMap<Movie, FranchiseCharactersDTO>().ForMember(fcdto => fcdto.Characters, opt => opt.MapFrom(c => c.Characters.Select(c => c.FullName).ToArray()));
        }
    }
}
