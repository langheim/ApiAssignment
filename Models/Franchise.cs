using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Assignment_3.Models
{
    // Table Name
    [Table("Franchise")]
    public class Franchise
    {
        // Add PrimaryKey
        public int Id { get; set; }
        // DataFields
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        // Add Relations
        public ICollection<Movie> Movies { get; set; }

    }

}
