// Dtos/OpenAiModels.cs
using System.Text.Json.Serialization;

namespace AutoescolaReisSite.Crm.Dtos
{
    public class ChatCompletionRequest
    {
        [JsonPropertyName("model")]
        public string Model { get; set; } = "gpt-4o-mini";

        [JsonPropertyName("messages")]
        public List<ChatMessage> Messages { get; set; } = new();

        [JsonPropertyName("temperature")]
        public double Temperature { get; set; } = 0.4;

        [JsonPropertyName("max_tokens")]
        public int MaxTokens { get; set; } = 300;
    }

    public class ChatMessage
    {
        [JsonPropertyName("role")]
        public string Role { get; set; } = "";

        [JsonPropertyName("content")]
        public string Content { get; set; } = "";
    }

    public class ChatCompletionResponse
    {
        [JsonPropertyName("choices")]
        public List<ChatChoice> Choices { get; set; } = new();
    }

    public class ChatChoice
    {
        [JsonPropertyName("message")]
        public ChatMessage Message { get; set; } = new();
    }
}