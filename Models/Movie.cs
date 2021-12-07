using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API_Assignment_3.Models
{
    /// <summary>
    /// Table Name
    /// </summary>
    [Table("Movie")]
    public class Movie
    {
        /// <summary>
        /// Add PrimaryKey
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// DataFields
        /// </summary>
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
        /// <summary>
        /// Add Relations
        /// </summary>
        public ICollection<Character> Characters { get; set; }
        public int FranchiseId { get; set; }
        public Franchise Franchise { get; set; }

    }

}
