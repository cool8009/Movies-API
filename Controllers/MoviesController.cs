using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movies_API.Data.MoviesDto;
using Movies_API.Services;

namespace Movies_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        //dependency injection
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        /// <summary>
        /// Controller endpoint for getting popular movies
        /// METHOD: GET
        /// </summary>
        /// <returns>A Task containing an IEnumerable of the Movie object</returns>
        [HttpGet]
        public async Task<IEnumerable<Movie>> GetMovies()
        {
            var movies = await _movieService.GetPopularMoviesAsync();
            return movies;
        }
        /// <summary>
        /// Controller endpoint for getting search result movies based on query string
        /// METHOD: GET 
        /// </summary>
        /// <param name="query"></param>
        /// <returns>A Task containing an IEnumerable of the Movie object</returns>        
        [HttpGet("{query}")]
        public async Task<IEnumerable<Movie>> GetMoviesFromSearchResults(string query)
        {
            var movies = await _movieService.GetSearchResultsAsync(query);
            return movies;
        }
    }
}
