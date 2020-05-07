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
    public class IndexModel : PageModel
    {
        HttpClient client;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            client = new HttpClient();
        }

        public List<MovieDTO> Movies = new List<MovieDTO>();
        public List<StudioDTO> Studios = new List<StudioDTO>();

        public async Task OnGetAsync()
        {


            await InitiateMoviesAsync();
            await InitiateStudisAsync();


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

        public async Task InitiateStudisAsync()
        {
            ApiHandler api = new ApiHandler(client);
            var studio = await api.GetStudiosAsync();

            foreach (var item in studio)
            {
                Studios.Add(item);
            }
        }

        public void SendMovieToMoviePage(int id)
        {

        }

    }
}
