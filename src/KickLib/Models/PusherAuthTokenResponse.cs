using Newtonsoft.Json;

namespace KickLib.Models
{
    public class PusherAuthTokenResponse
    {
        [JsonProperty("auth")]
        public string Auth { get; set; }
    }
}
