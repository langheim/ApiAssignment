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
    [Table("Character")]
    public class Character
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
        public string FullName { get; set; }
        [MaxLength(50)]
        public string Alias { get; set; }
        [MaxLength(25)]
        public string Gender { get; set; }
        [MaxLength(250)]
        public string ImageURL { get; set; }
        /// <summary>
        /// Add Relations
        /// </summary>
        public ICollection<Movie> Movies { get; set; }

    }

}
