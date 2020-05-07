using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.API;
using System.Net.Http;
using Microsoft.Extensions.Logging;
using RazorPages.DTO;

namespace RazorPages.Pages
{

    public class MovieModel : PageModel
    {
        HttpClient client;
        private readonly ILogger<MovieModel> _logger;

        public MovieModel(ILogger<MovieModel> logger)
        {
            _logger = logger;
            client = new HttpClient();
        }

        public int MovieId { get; set; }
        public MovieDTO FetchedMovie { get; set; }
        public List<StudioDTO> StudiosRelatedToReveiews = new List<StudioDTO>();
        public List<StudioDTO> StudiosRelatedToReveiewsSorted = new List<StudioDTO>();
        public List<ReviewDTO> Reviews = new List<ReviewDTO>();
        public List<TriviaDTO> Trivias = new List<TriviaDTO>();
        public List<StudioDTO> Studios = new List<StudioDTO>();

        public async Task OnGetAsync(int id)
        {
            MovieId = id;
            await GetMovieFromDB();
            await GetReviews();
            await GetTrivias();
            await GetStudios();

            StudiosRelatedToReveiewsSorted = StudiosRelatedToReveiews.GroupBy(x => x.Id)
                                                                    .Select(g => g.First())
                                                                    .ToList();

        }
        public async Task GetReviews()
        {
            ApiHandler api = new ApiHandler(client);
            var reviewsFromDB = await api.GetReviewFromMovie(MovieId);

            foreach (var item in reviewsFromDB)
            {
                Reviews.Add(item);
            }
        }

        public async Task GetStudios()
        {
            ApiHandler api = new ApiHandler(client);
            var studiosFromDB = await api.GetStudiosAsync();

            foreach (var item in studiosFromDB)
            {
                Studios.Add(item);
            }

            for (int i = 0; i < Reviews.Count; i++)
            {
                for (int j = 0; j < Studios.Count; j++)
                {
                    if (Studios[j].Id == Reviews[i].StudioId)
                    {
                        StudiosRelatedToReveiews.Add(studiosFromDB[j]);
                    }
                }
            }

        }

        public async Task GetTrivias()
        {
            ApiHandler api = new ApiHandler(client);

            var triviasFromDB = await api.GetTriviaFromMovie(MovieId);

            foreach (var item in triviasFromDB)
            {
                Trivias.Add(item);
            }

        }


        public async Task GetMovieFromDB()
        {
            ApiHandler api = new ApiHandler(client);

            FetchedMovie = await api.GetSpecificMovieAsync(MovieId);
        }

        public async Task<IActionResult> OnPostDelete()
        {
            ApiHandler api = new ApiHandler(client);
            FetchedMovie = await api.GetSpecificMovieAsync(Convert.ToInt32(Request.Form["ButtonId"]));
            await api.DeleteMovie(FetchedMovie.Id);

            return RedirectToPage("./Index");
        }


    }
}
