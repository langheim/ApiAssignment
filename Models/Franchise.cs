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
    [Table("Franchise")]
    public class Franchise
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
        public string Name { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        /// <summary>
        /// Add Relations
        /// </summary>
        public ICollection<Movie> Movies { get; set; }

    }

}
