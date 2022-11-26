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
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        [HttpGet]
        public async Task<IEnumerable<Movie>> GetMovies()
        {
            var movies = await _movieService.GetAsync();
            return movies;
        }
        [HttpGet("{query}")]
        public async Task<IEnumerable<Movie>> GetMoviesFromSearchResults(string query)
        {
            var movies = await _movieService.GetSearchResultsAsync(query);
            return movies;
        }
    }
}
