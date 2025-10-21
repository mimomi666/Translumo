using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Translumo.Translation.Multimodal
{
    public class MultimodalResponse
    {
        [JsonPropertyName("choices")]
        public List<Choice> Choices { get; set; }

        [JsonPropertyName("error")]
        public Error ErrorObj { get; set; }

        public class Choice
        {
            [JsonPropertyName("message")]
            public ResponseMessage Message { get; set; }
        }

        public class ResponseMessage
        {
            [JsonPropertyName("content")]
            public string Content { get; set; }
        }

        public class Error
        {
            [JsonPropertyName("message")]
            public string Message { get; set; }

            [JsonPropertyName("type")]
            public string Type { get; set; }
        }
    }
}
