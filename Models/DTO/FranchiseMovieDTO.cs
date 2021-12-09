using System.Collections.Generic;

namespace API_Assignment_3.Models.DTO
{
    public class FranchiseMovieDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> Movies { get; set; }
    }
}
