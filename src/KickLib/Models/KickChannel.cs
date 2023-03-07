using Newtonsoft.Json;

namespace KickLib.Models
{
    public class KickChannel
    {
        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("livestream")]
        public Livestream Livestream { get; set; }
        [JsonProperty("chatroom")]
        public ChatRoom ChatRoom { get; set; }
    }
}
