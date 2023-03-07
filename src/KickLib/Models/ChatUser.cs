using Newtonsoft.Json;

namespace KickLib.Models
{
    public partial class ChatUser
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("role")]
        public object Role { get; set; }

        [JsonProperty("isSuperAdmin")]
        public bool IsSuperAdmin { get; set; }

        [JsonProperty("profile_thumb")]
        public object ProfileThumb { get; set; }

        [JsonProperty("verified")]
        public bool Verified { get; set; }

        [JsonProperty("follower_badges")]
        public object[] FollowerBadges { get; set; }

        [JsonProperty("is_subscribed")]
        public bool IsSubscribed { get; set; }

        [JsonProperty("is_founder")]
        public bool IsFounder { get; set; }

        [JsonProperty("months_subscribed")]
        public long MonthsSubscribed { get; set; }

        [JsonProperty("quantity_gifted")]
        public long QuantityGifted { get; set; }
    }
}
