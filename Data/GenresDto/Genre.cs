using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Movies_API.Data.GenreDto
{
    public class Genre
    {
        [JsonProperty("id")]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
