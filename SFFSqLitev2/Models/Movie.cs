using System.Collections.Generic;

namespace SFFSqLite.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int MaxRentAmount { get; set; }
        public string ImageURL { get; set; }

    }
}