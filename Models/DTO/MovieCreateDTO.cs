namespace API_Assignment_3.Models.DTO
{
    public class MovieCreateDTO
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public string ReleaseYear { get; set; }
        public string Director { get; set; }
        public int FranchiseId { get; set; }
    }
}
