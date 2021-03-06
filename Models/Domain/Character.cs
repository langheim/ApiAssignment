using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Assignment_3.Models.Domain
{
    // Table Name
    [Table("Character")]
    public class Character
    {
        // Add PrimaryKey
        public int Id { get; set; }
        // DataFields
        [Required]
        [MaxLength(50)]
        public string FullName { get; set; }
        [MaxLength(50)]
        public string Alias { get; set; }
        [MaxLength(25)]
        public string Gender { get; set; }
        [MaxLength(250)]
        public string ImageURL { get; set; }
        // Add Relations
        public ICollection<Movie> Movies { get; set; }

    }

}
