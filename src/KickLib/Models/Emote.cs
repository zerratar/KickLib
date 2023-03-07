using Newtonsoft.Json;

namespace KickLib.Models
{
    public partial class Emote
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("channel_id")]
        public long? ChannelId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("subscribers_only")]
        public bool SubscribersOnly { get; set; }
    }
}
