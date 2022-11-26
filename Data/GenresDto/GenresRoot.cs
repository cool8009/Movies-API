using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Movies_API.Data.GenreDto
{
    public class GenresRoot
    {
        [JsonProperty("genres")]
        [JsonPropertyName("genres")]
        public List<Genre> Genres { get; set; }
    }
}
