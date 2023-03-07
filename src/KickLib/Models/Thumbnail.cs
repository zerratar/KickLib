using Newtonsoft.Json;

namespace KickLib.Models
{
    public partial class Thumbnail
    {
        [JsonProperty("responsive")]
        public Uri Responsive { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }
    }
}
