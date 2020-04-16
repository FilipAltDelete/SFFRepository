namespace SFFSqLite.Models
{
    public class Trivia
    {
        public int Id { get; set; }
        public string TriviaString { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }

    }
}