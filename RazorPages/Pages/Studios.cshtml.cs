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
    public class StudiosModel : PageModel
    {

        HttpClient client;
        private readonly ILogger<MovieModel> _logger;

        public StudiosModel(ILogger<MovieModel> logger)
        {
            _logger = logger;
            client = new HttpClient();
        }


        public List<StudioDTO> Studios = new List<StudioDTO>();
        public async Task OnGetAsync()
        {
            await GetStudios();
        }

        public async Task GetStudios()
        {
            ApiHandler api = new ApiHandler(client);
            var studiosFromDB = await api.GetStudiosAsync();

            foreach (var item in studiosFromDB)
            {
                Studios.Add(item);
            }

        }
    }
}
