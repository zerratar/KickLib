using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KickLib.Models
{
    public partial class KickChatMessage
    {
        [JsonProperty("message")]
        public KickMessage Message { get; set; }

        [JsonProperty("user")]
        public KickChatUser User { get; set; }
    }

    public partial class KickMessage
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

    public partial class KickChatUser
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


    public class KickChannel
    {
        [JsonProperty("user")]
        public KickUser User { get; set; }

        [JsonProperty("livestream")]
        public KickLivestream Livestream { get; set; }
        [JsonProperty("chatroom")]
        public KickChatRoom ChatRoom { get; set; }
    }

    public partial class KickLivestream
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
        public CategoryElement[] Categories { get; set; }

        [JsonProperty("tags")]
        public object[] Tags { get; set; }
    }

    public partial class CategoryElement
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("category_id")]
        public long CategoryId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("tags")]
        public string[] Tags { get; set; }

        [JsonProperty("description")]
        public object Description { get; set; }

        [JsonProperty("deleted_at")]
        public object DeletedAt { get; set; }
    }

    public partial class Thumbnail
    {
        [JsonProperty("responsive")]
        public Uri Responsive { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }
    }
    public class KickChatRoom
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("chatable_type")]
        public string ChatableType { get; set; }
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
        [JsonProperty("chat_mode_old")]
        public string ChatModeOld { get; set; }
        [JsonProperty("chat_mode")]
        public string ChatMode { get; set; }
        [JsonProperty("chatable_id")]
        public long ChatableId { get; set; }
        [JsonProperty("slow_mode")]
        public bool SlowMode { get; set; }
    }

    public class PusherAuthTokenResponse
    {
        [JsonProperty("auth")]
        public string Auth { get; set; }
    }

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
        public KickUser User { get; set; }

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

    public partial class KickUser
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
