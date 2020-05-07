namespace RazorPages.DTO
{
    public class ReviewDTO
    {
        public int Id { get; set; }
        public int Grade { get; set; }
        public string Comment { get; set; }
        public int StudioId { get; set; }
        public int MovieId { get; set; }
    }
}