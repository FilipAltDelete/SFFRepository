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
    public class AddTriviaModel : PageModel
    {

        HttpClient client;
        private readonly ILogger<MovieModel> _logger;

        public AddTriviaModel(ILogger<MovieModel> logger)
        {
            _logger = logger;
            client = new HttpClient();
        }

        public int MovieId { get; set; }
        public MovieDTO FetchedMovie { get; set; }

        public async Task OnGetAsync(int id)
        {
            MovieId = id;
            await GetMovieFromDB();

        }


        public async Task<IActionResult> OnPostAsync()
        {
            ApiHandler api = new ApiHandler(client);

            FetchedMovie = await api.GetSpecificMovieAsync(Convert.ToInt32(Request.Form["movieId"]));
            TriviaDTO newTrivia = new TriviaDTO();
            newTrivia.MovieId = FetchedMovie.Id;//Convert.ToInt32(Request.Form["movieId"]);
            newTrivia.TriviaString = Request.Form["newTrivia"];

            await api.PostNewTrivia(newTrivia);

            return Redirect($"./Movie?id={FetchedMovie.Id}");

        }


        public async Task GetMovieFromDB()
        {
            ApiHandler api = new ApiHandler(client);

            FetchedMovie = await api.GetSpecificMovieAsync(MovieId);
        }
    }
}
