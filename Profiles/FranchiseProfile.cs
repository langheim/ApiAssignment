using API_Assignment_3.Models.Domain;
using API_Assignment_3.Models.DTO;
using AutoMapper;

namespace API_Assignment_3.Profiles
{
    public class FranchiseProfile : Profile
    {
        public FranchiseProfile()
        {
            // Franchise<->FranchiseReadDTO
            CreateMap<Franchise, FranchiseReadDTO>().ReverseMap();
            // Franchise<->FranchiseCreateDTO
            CreateMap<Franchise, FranchiseCreateDTO>().ReverseMap();
        }
    }
}
