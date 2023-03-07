using Newtonsoft.Json;

namespace KickLib.Models
{
    public partial class EmoteSource
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("user_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? UserId { get; set; }

        [JsonProperty("slug", NullValueHandling = NullValueHandling.Ignore)]
        public string Slug { get; set; }

        [JsonProperty("playback_url", NullValueHandling = NullValueHandling.Ignore)]
        public Uri PlaybackUrl { get; set; }

        [JsonProperty("name_updated_at")]
        public object NameUpdatedAt { get; set; }

        [JsonProperty("vod_enabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool? VodEnabled { get; set; }

        [JsonProperty("subscription_enabled", NullValueHandling = NullValueHandling.Ignore)]
        public bool? SubscriptionEnabled { get; set; }

        [JsonProperty("emotes")]
        public Emote[] Emotes { get; set; }

        [JsonProperty("can_host", NullValueHandling = NullValueHandling.Ignore)]
        public bool? CanHost { get; set; }

        [JsonProperty("user", NullValueHandling = NullValueHandling.Ignore)]
        public User User { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }
    }
}
