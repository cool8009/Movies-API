using Movies_API.Data;
using Movies_API.Data.GenreDto;
using Movies_API.Data.ImagesDtos;
using Movies_API.Data.MoviesDto;
using System.Text.Json;
using GenresRoot = Movies_API.Data.GenreDto.GenresRoot;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Movies_API.Services
{
    public class MovieService : IMovieService
    {
        private readonly string apiKey = "922cce5f16e05b95324be31eb13ee009";
        HttpClient httpClient = new HttpClient();
        public async Task<List<Movie>> GetAsync()
        {
            var uri = new Uri($"https://api.themoviedb.org/3/movie/popular?api_key={apiKey}&page=1");
            var data = await httpClient.GetFromJsonAsync<MoviesRoot>(uri);

            var imageUri = new Uri($"https://api.themoviedb.org/3/configuration?api_key={apiKey}");
            var imageData = await httpClient.GetFromJsonAsync<ImagesRoot>(imageUri);

            var genreUri = new Uri($"https://api.themoviedb.org/3/genre/movie/list?api_key={apiKey}&language=en-US");
            var genreData = await httpClient.GetFromJsonAsync<GenresRoot>(genreUri);

            return getMoviesWithCorrectInfo(data.Results, imageData, genreData);

        }

        public async Task<List<Movie>> GetSearchResultsAsync(string searchtext)
        {
            var uri = new Uri($"https://api.themoviedb.org/3/search/movie?api_key={apiKey}&language=en-US&query={searchtext}");
            var data = await httpClient.GetFromJsonAsync<MoviesRoot>(uri);

            var imageUri = new Uri($"https://api.themoviedb.org/3/configuration?api_key={apiKey}");
            var imageData = await httpClient.GetFromJsonAsync<ImagesRoot>(imageUri);

            var genreUri = new Uri($"https://api.themoviedb.org/3/genre/movie/list?api_key={apiKey}&language=en-US");
            var genreData = await httpClient.GetFromJsonAsync<GenresRoot>(genreUri);

            return getMoviesWithCorrectInfo(data.Results, imageData, genreData);

        }

        private List<Movie> getMoviesWithCorrectInfo(List<Movie> movies, ImagesRoot imageRoot, GenresRoot genreRoot)
        {
            foreach (var movie in movies)
            {
                var newUri = new Uri($"{imageRoot.Images.BaseUrl}w500{movie.PosterPath}");
                movie.PosterPath = newUri.ToString();
                foreach (var item in genreRoot.Genres)
                {
                    if (movie.GenreIds.Contains(item.Id))
                    {
                        movie.GenreNames = new List<string>();
                        movie.GenreNames.Add(item.Name);
                    }

                }
            }
                return movies;
        }

    }

}
