using System.Collections.Generic;

namespace API_Assignment_3.Models.DTO
{
    public class CharacterReadDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Alias { get; set; }
        public string Gender { get; set; }
        public string ImageURL { get; set; }
        public List<int> Movies { get; set; }
    }
}
