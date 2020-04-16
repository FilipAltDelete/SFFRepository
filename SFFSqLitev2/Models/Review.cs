namespace SFFSqLite.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int Grade { get; set; }
        public string Comment { get; set; }
        public int StudioId { get; set; }
        public Studio Studio { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
    }
}