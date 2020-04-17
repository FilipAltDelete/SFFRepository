using System;
using System.Collections.Generic;
using System.Linq;

namespace SFFSqLite.Models
{
    public class RentingHandler
    {
        public bool MovieRentingLimiter(List<RentedMovie> totalRentedMovieList, RentedMovie rentedMovie, Movie movie)
        {

            var totalDuplicates = totalRentedMovieList.GroupBy(rentedMovie => rentedMovie.MovieId);

            foreach (var group in totalDuplicates)
            {
                var grp = group.Count();
                if (grp >= movie.MaxRentAmount + 1)
                {
                    return false;
                }
            }

            return true;
        }

        public Etikett ReturnEtikett(Movie movie, Studio studio)
        {

            Etikett e = new Etikett();
            e.FilmName = movie.Title;
            e.Ort = studio.City;
            e.Datum = DateTime.Now;

            return e;

        }

        public Trivia AddTrivia(string triviaString, RentedMovie movieToReturn)
        {
            Trivia trivia = new Trivia();

            trivia.MovieId = movieToReturn.MovieId;
            trivia.TriviaString = triviaString;

            return trivia;
        }


        public Review ReviewRentedMovie(int gradeValue,string comment ,RentedMovie movieToReturn)
        {

            Review r = new Review();

            r.MovieId = movieToReturn.MovieId;
            r.StudioId = movieToReturn.StudioId;
            r.Comment = comment;
            r.Grade = gradeValue;

            return r;
        }

        public Review ReviewMovie(int gradeValue,string comment ,Movie movie, Studio studio)
        {

            Review r = new Review();

            r.MovieId = movie.Id;
            r.StudioId = studio.Id;
            r.Comment = comment;
            r.Grade = gradeValue;

            return r;
        }
    }
}