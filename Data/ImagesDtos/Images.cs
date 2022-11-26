using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Movies_API.Data.ImagesDtos
{
    public class Images
    {
        [JsonProperty("base_url")]
        [JsonPropertyName("base_url")]
        public string BaseUrl { get; set; }

        [JsonProperty("secure_base_url")]
        [JsonPropertyName("secure_base_url")]
        public string SecureBaseUrl { get; set; }

        [JsonProperty("backdrop_sizes")]
        [JsonPropertyName("backdrop_sizes")]
        public List<string> BackdropSizes { get; set; }

        [JsonProperty("logo_sizes")]
        [JsonPropertyName("logo_sizes")]
        public List<string> LogoSizes { get; set; }

        [JsonProperty("poster_sizes")]
        [JsonPropertyName("poster_sizes")]
        public List<string> PosterSizes { get; set; }

        [JsonProperty("profile_sizes")]
        [JsonPropertyName("profile_sizes")]
        public List<string> ProfileSizes { get; set; }

        [JsonProperty("still_sizes")]
        [JsonPropertyName("still_sizes")]
        public List<string> StillSizes { get; set; }
    }
}
