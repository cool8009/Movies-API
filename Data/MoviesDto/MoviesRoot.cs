// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Movies_API.Data.MoviesDto
{
    public class MoviesRoot
    {
        [JsonProperty("page")]
        [JsonPropertyName("page")]
        public int? Page { get; set; }

        [JsonProperty("results")]
        [JsonPropertyName("results")]
        public List<Movie> Results { get; set; }

        [JsonProperty("total_pages")]
        [JsonPropertyName("total_pages")]
        public int? TotalPages { get; set; }

        [JsonProperty("total_results")]
        [JsonPropertyName("total_results")]
        public int? TotalResults { get; set; }
    }
}