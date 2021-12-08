using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Assignment_3.Models
{
    // Table Name
    [Table("Movie")]
    public class Movie
    {
        // Add PrimaryKey
        public int Id { get; set; }
        // DataFields
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }
        [MaxLength(100)]
        public string Genre { get; set; }
        [Required]
        [MaxLength(4)]
        public string ReleaseYear { get; set; }
        [Required]
        [MaxLength(50)]
        public string Director { get; set; }
        [MaxLength(250)]
        public string ImageURL { get; set; }
        [MaxLength(250)]
        public string TrailerURL { get; set; }
        // Add Relations
        public ICollection<Character> Characters { get; set; }
        public int FranchiseId { get; set; }
        public Franchise Franchise { get; set; }

    }

}
