﻿using API_Assignment_3.Models.Domain;
using API_Assignment_3.Models.DTO;
using AutoMapper;
using System.Linq;

namespace API_Assignment_3.Profiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            // Movie->MovieReadDTO
            CreateMap<Movie, MovieReadDTO>()
            // Turning related characters into int arrays
            .ForMember(cdto => cdto.Characters, opt => opt
            .MapFrom(c => c.Characters.Select(c => c.Id).ToArray()));
            // MovieCreateDTO->Movie
            CreateMap<MovieCreateDTO, Movie>();
            // CharacterEditDTO->Character
            CreateMap<MovieEditDTO, Movie>();
        }
    }
}
