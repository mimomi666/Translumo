using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Translumo.Translation.Multimodal
{
    public class MultimodalRequest
    {
        [JsonPropertyName("model")]
        public string Model { get; set; }

        [JsonPropertyName("messages")]
        public List<Message> Messages { get; set; }

        [JsonPropertyName("max_tokens")]
        public int MaxTokens { get; set; } = 1000;

        public class Message
        {
            [JsonPropertyName("role")]
            public string Role { get; set; }

            [JsonPropertyName("content")]
            public List<Content> ContentList { get; set; }
        }

        public class Content
        {
            [JsonPropertyName("type")]
            public string Type { get; set; }

            [JsonPropertyName("text")]
            public string Text { get; set; }

            [JsonPropertyName("image_url")]
            public ImageUrl ImageUrlObj { get; set; }
        }

        public class ImageUrl
        {
            [JsonPropertyName("url")]
            public string Url { get; set; }
        }
    }
}
