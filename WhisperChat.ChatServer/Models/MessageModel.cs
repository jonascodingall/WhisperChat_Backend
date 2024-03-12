using System.Text.Json.Serialization;

namespace WhisperChat.ChatServer.Models
{
#nullable enable
    public class MessageModel
    {
        public int Id { get; set; }
        [JsonPropertyName("message")]
        public string? Message { get; set; }

        [JsonPropertyName("sendTime")]
        public string? SentTime { get; set; }

        [JsonPropertyName("senderId")]
        public string? Sender { get; set; }

        [JsonPropertyName("recipientId")]
        public string? RecipientId { get; set; }
    }
}
