using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using RazorPages.API;
using RazorPages.DTO;

namespace RazorPages.Pages
{
    public class ReviewMovieModel : PageModel
    {
        HttpClient client;
        private readonly ILogger<MovieModel> _logger;

        public ReviewMovieModel(ILogger<MovieModel> logger)
        {
            _logger = logger;
            client = new HttpClient();
        }
        public int MovieId { get; set; }
        public MovieDTO FetchedMovie { get; set; }
        public List<StudioDTO> Studios = new List<StudioDTO>();

        public async Task OnGetAsync(int id)
        {
            MovieId = id;
            await GetMovieFromDB();

        }

        public async Task<IActionResult> OnPost()
        {
            ApiHandler api = new ApiHandler(client);

            var studiosFromDB = await api.GetStudiosAsync();
            foreach (var item in studiosFromDB)
            {
                Studios.Add(item);
            }

            FetchedMovie = await api.GetSpecificMovieAsync(Convert.ToInt32(Request.Form["movieId"]));
            ReviewDTO newReview = new ReviewDTO();
            newReview.MovieId = FetchedMovie.Id;//Convert.ToInt32(Request.Form["movieId"]);
            newReview.Grade = Convert.ToInt32(Request.Form["newGrade"]);
            newReview.Comment = Request.Form["newComment"];

            int studioAmount = Studios.Count();
            Random r = new Random();
            int studio = r.Next(1, studioAmount + 1);
            newReview.StudioId = studio;

            await api.PostNewReview(newReview);

            return Redirect($"./Movie?id={FetchedMovie.Id}");

        }

        public async Task GetMovieFromDB()
        {
            ApiHandler api = new ApiHandler(client);
            FetchedMovie = await api.GetSpecificMovieAsync(MovieId);
        }
    }
}
