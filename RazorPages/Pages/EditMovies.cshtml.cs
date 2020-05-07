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
    public class EditMoviesModel : PageModel
    {
        HttpClient client;
        private readonly ILogger<IndexModel> _logger;

        public EditMoviesModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            client = new HttpClient();
        }

        public List<MovieDTO> Movies = new List<MovieDTO>();
        public async Task OnGetAsync()
        {

            await InitiateMoviesAsync();

        }
        public async Task<IActionResult> OnPostAsync()
        {
            MovieDTO newMovie = new MovieDTO();
            newMovie.Title = Request.Form["newTitle"];
            newMovie.Genre = Request.Form["newGenre"];
            newMovie.ImageURL = Request.Form["newImage"];
            newMovie.MaxRentAmount = 3;

            ApiHandler api = new ApiHandler(client);

            await api.PostNewMovie(newMovie);
            return RedirectToPage("./Index");

        }
        public async Task InitiateMoviesAsync()
        {
            ApiHandler api = new ApiHandler(client);
            var movie = await api.GetMovieAsync();

            foreach (var item in movie)
            {
                Movies.Add(item);
            }

        }

    }
}
