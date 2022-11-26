using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Movies_API.Data.ImagesDtos
{
    public class ImagesRoot
    {
        [JsonProperty("images")]
        [JsonPropertyName("images")]
        public Images Images { get; set; }

        [JsonProperty("change_keys")]
        [JsonPropertyName("change_keys")]
        public List<string> ChangeKeys { get; set; }
    }
}
