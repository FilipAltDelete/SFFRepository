using System;
using System.Net.Http;
using System.Threading.Tasks;
using RazorPages.DTO;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Collections.Specialized;

namespace RazorPages.API
{

    public interface IApiHandler
    {
    }

    public class ApiHandler : IApiHandler
    {

        HttpClient _client;

        public ApiHandler(HttpClient client)
        {
            _client = client;
        }

        public async Task<MovieDTO[]> GetMovieAsync(string url = "http://localhost:5000/api/Movie")
        {
            HttpResponseMessage response = await _client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var movie = await response.Content.ReadAsAsync<MovieDTO[]>();
                return movie;
            }
            return null;
        }

        public async Task<MovieDTO> GetSpecificMovieAsync(int Id)
        {
            string url = $"http://localhost:5000/api/Movie/{Id}";
            HttpResponseMessage response = await _client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var movie = await response.Content.ReadAsAsync<MovieDTO>();
                return movie;
            }
            return null;
        }

        public async Task<MovieDTO> PostNewMovie(MovieDTO movie)
        {
            string url = "http://localhost:5000/api/Movie";

            HttpResponseMessage response = await _client.PostAsJsonAsync(url, movie);

            return null;

        }

        public async Task<MovieDTO> DeleteMovie(int id)
        {
            string url = $"http://localhost:5000/api/Movie/{id}";

            HttpResponseMessage response = await _client.DeleteAsync(url);

            return null;
        }

        public async Task<ReviewDTO[]> GetReviewFromMovie(int Id)
        {
            //http://localhost:5000/api/Review/5/reviews
            string url = $"http://localhost:5000/api/Review/{Id}/reviews";
            HttpResponseMessage response = await _client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var review = await response.Content.ReadAsAsync<ReviewDTO[]>();
                return review;

            }
            return null;
        }
        public async Task<ReviewDTO> PostNewReview(ReviewDTO review)
        {
            string url = "http://localhost:5000/api/Review";

            HttpResponseMessage response = await _client.PostAsJsonAsync(url, review);
            return null;
        }

        public async Task<TriviaDTO[]> GetTriviaFromMovie(int Id)
        {

            string url = $"http://localhost:5000/api/Trivia/{Id}/trivias";
            HttpResponseMessage response = await _client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var trivia = await response.Content.ReadAsAsync<TriviaDTO[]>();
                return trivia;
            }

            return null;
        }

        public async Task<TriviaDTO> PostNewTrivia(TriviaDTO trivia)
        {
            string url = "http://localhost:5000/api/Trivia";

            HttpResponseMessage response = await _client.PostAsJsonAsync(url, trivia);

            return null;
        }

        public async Task<StudioDTO[]> GetStudiosAsync(string url = "http://localhost:5000/api/Studio")
        {

            HttpResponseMessage response = await _client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var studio = await response.Content.ReadAsAsync<StudioDTO[]>();
                return studio;
            }
            return null;
        }

    }
}