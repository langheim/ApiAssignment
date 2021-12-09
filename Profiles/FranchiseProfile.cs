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
            // Create map for Franchise to FranchiseMovieDTO
            CreateMap<Franchise, FranchiseMovieDTO>().ForMember(fdto => fdto.Movies, opt => opt
            .MapFrom(c => c.Movies.Select(c => c.Title).ToArray()));
            // Create map for Characters in movies
            CreateMap<Movie, FranchiseCharactersDTO>().ForMember(cdto => cdto.Characters, opt => opt
            .MapFrom(c => c.Characters.Select(c => c.FullName).ToArray()));
        }
    }
}
