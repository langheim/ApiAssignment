using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Assignment_3.Models.DTO
{
    public class FranchiseCharactersDTO
    {
        public int FranchiseId { get; set; }
        public List<string> Characters { get; set; }
    }
}
