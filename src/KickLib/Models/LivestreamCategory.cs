using Newtonsoft.Json;

namespace KickLib.Models
{
    public partial class LivestreamCategory
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
}
