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
        //my personal API key for use with the OMDB API
        private readonly string apiKey = "922cce5f16e05b95324be31eb13ee009";
        HttpClient httpClient = new HttpClient();

        /// <summary>
        ///     Gets the list of popular movies from the API, 
        ///     with updated genre and image url for each of the movies on the list.
        /// </summary>
        /// <returns>A Task result containing a List of the Movie object</returns>
        public async Task<List<Movie>> GetPopularMoviesAsync()
        {
            var uri = new Uri($"https://api.themoviedb.org/3/movie/popular?api_key={apiKey}&page=1");
            var data = await httpClient.GetFromJsonAsync<MoviesRoot>(uri);

            var imageUri = new Uri($"https://api.themoviedb.org/3/configuration?api_key={apiKey}");
            var imageData = await httpClient.GetFromJsonAsync<ImagesRoot>(imageUri);

            var genreUri = new Uri($"https://api.themoviedb.org/3/genre/movie/list?api_key={apiKey}&language=en-US");
            var genreData = await httpClient.GetFromJsonAsync<GenresRoot>(genreUri);

            return getMoviesWithCorrectInfo(data.Results, imageData, genreData);

        }

        /// <summary>
        /// Gets the list of search results based on the query string from the API, 
        /// with updated genre and image url for each of the movies on the list.
        /// </summary>
        /// <param name="searchtext"></param>
        /// <returns>A Task result containing a List of the Movie object</returns>
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
        /// <summary>
        /// Appends the correct updated info to the movie object, including genre and image URL.
        /// More info could be found at the API Docs: https://developers.themoviedb.org/3/getting-started/images
        /// </summary>
        /// <param name="movies"></param>
        /// <param name="imageRoot"></param>
        /// <param name="genreRoot"></param>
        /// <returns>A List of the Movie object</returns>
        private List<Movie> getMoviesWithCorrectInfo(List<Movie> movies, ImagesRoot imageRoot, GenresRoot genreRoot)
        {
            //loop through each movie and append the correct info to the object
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
