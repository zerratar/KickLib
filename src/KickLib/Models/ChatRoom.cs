using Newtonsoft.Json;

namespace KickLib.Models
{
    public class ChatRoom
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
}
