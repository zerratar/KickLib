using Newtonsoft.Json;

namespace KickLib.Models
{
    public partial class Message
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("message")]
        public string Content { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("replied_to")]
        public object RepliedTo { get; set; }

        [JsonProperty("is_info")]
        public object IsInfo { get; set; }

        [JsonProperty("link_preview")]
        public object LinkPreview { get; set; }

        [JsonProperty("chatroom_id")]
        public long ChatroomId { get; set; }

        [JsonProperty("role")]
        public object Role { get; set; }

        [JsonProperty("created_at")]
        public long CreatedAt { get; set; }

        [JsonProperty("action")]
        public object Action { get; set; }

        [JsonProperty("optional_message")]
        public object OptionalMessage { get; set; }

        [JsonProperty("months_subscribed")]
        public long MonthsSubscribed { get; set; }

        [JsonProperty("subscriptions_count")]
        public object SubscriptionsCount { get; set; }

        [JsonProperty("giftedUsers")]
        public object GiftedUsers { get; set; }
    }
}
