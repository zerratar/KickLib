using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Reflection;

namespace KickLib.Models
{
    public partial class ChatMessage
    {
        [JsonProperty("message")]
        public Message Message { get; set; }

        [JsonProperty("user")]
        public ChatUser User { get; set; }
    }

    [JsonConverter(typeof(JsonPathConverter))]
    public partial class DeletedChatMessage
    {
        [JsonProperty("deletedMessage.id")]
        public string Id { get; set; }
        [JsonProperty("deletedMessage.deleted_by")]
        public long DeletedBy { get; set; }
        [JsonProperty("deletedMessage.chatroom_id")]
        public long ChatroomId { get; set; }
    }

    class JsonPathConverter : JsonConverter
    {
        public override object ReadJson(JsonReader reader, Type objectType,
                                        object existingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);
            object targetObj = Activator.CreateInstance(objectType);

            foreach (PropertyInfo prop in objectType.GetProperties()
                                                    .Where(p => p.CanRead && p.CanWrite))
            {
                JsonPropertyAttribute att = prop.GetCustomAttributes(true)
                                                .OfType<JsonPropertyAttribute>()
                                                .FirstOrDefault();

                string jsonPath = (att != null ? att.PropertyName : prop.Name);
                JToken token = jo.SelectToken(jsonPath);

                if (token != null && token.Type != JTokenType.Null)
                {
                    object value = token.ToObject(prop.PropertyType, serializer);
                    prop.SetValue(targetObj, value, null);
                }
            }

            return targetObj;
        }

        public override bool CanConvert(Type objectType)
        {
            // CanConvert is not called when [JsonConverter] attribute is used
            return false;
        }

        public override bool CanWrite
        {
            get { return false; }
        }

        public override void WriteJson(JsonWriter writer, object value,
                                       JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
