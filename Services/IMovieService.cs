
using Movies_API.Data.MoviesDto;

namespace Movies_API.Services
{
    public interface IMovieService
    {
        Task<List<Movie>> GetPopularMoviesAsync();
        Task<List<Movie>> GetSearchResultsAsync(string searchtext);
    }
}