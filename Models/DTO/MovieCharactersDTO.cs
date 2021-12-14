﻿using System.Collections.Generic;

namespace API_Assignment_3.Models.DTO
{
    public class MovieCharactersDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string ReleaseYear { get; set; }
        public string Director { get; set; }
        public string ImageURL { get; set; }
        public string TrailerURL { get; set; }
        public List<string> Characters { get; set; }
        public int? FranchiseId { get; set; }
    }
}
