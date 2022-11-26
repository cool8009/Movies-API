
using Movies_API.Data.MoviesDto;

namespace Movies_API.Services
{
    public interface IMovieService
    {
        Task<List<Movie>> GetAsync();
        Task<List<Movie>> GetSearchResultsAsync(string searchtext);
    }
}