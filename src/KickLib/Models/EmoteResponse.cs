using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    public partial class User
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("agreed_to_terms")]
        public bool AgreedToTerms { get; set; }

        [JsonProperty("bio")]
        public string Bio { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("instagram")]
        public string Instagram { get; set; }

        [JsonProperty("twitter")]
        public string Twitter { get; set; }

        [JsonProperty("youtube")]
        public string Youtube { get; set; }

        [JsonProperty("discord")]
        public string Discord { get; set; }

        [JsonProperty("tiktok")]
        public string Tiktok { get; set; }

        [JsonProperty("facebook")]
        public string Facebook { get; set; }

        [JsonProperty("profile_pic")]
        public Uri ProfilePic { get; set; }
    }
}
