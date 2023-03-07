using Newtonsoft.Json;

namespace KickLib.Models
{
    public partial class Livestream
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("channel_id")]
        public long ChannelId { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("session_title")]
        public string SessionTitle { get; set; }

        [JsonProperty("is_live")]
        public bool IsLive { get; set; }

        [JsonProperty("risk_level_id")]
        public object RiskLevelId { get; set; }

        [JsonProperty("source")]
        public object Source { get; set; }

        [JsonProperty("twitch_channel")]
        public object TwitchChannel { get; set; }

        [JsonProperty("duration")]
        public long Duration { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("is_mature")]
        public bool IsMature { get; set; }

        [JsonProperty("viewer_count")]
        public long ViewerCount { get; set; }

        [JsonProperty("thumbnail")]
        public Thumbnail Thumbnail { get; set; }

        [JsonProperty("viewers")]
        public long Viewers { get; set; }

        [JsonProperty("categories")]
        public LivestreamCategory[] Categories { get; set; }

        [JsonProperty("tags")]
        public object[] Tags { get; set; }
    }
}
