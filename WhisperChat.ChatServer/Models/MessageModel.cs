namespace WhisperChat.ChatServer.Models
{
#nullable enable
    public class MessageModel
    {
        public string? Message { get; set; }
        public string? SentTime { get; set; }
        public string? Sender { get; set; }
        public MessageDirection Direction { get; set; }
        public Position Position { get; set; }
        public MessageType? Type { get; set; }
        public MessagePayload? Payload { get; set; }
    }

    public enum MessageDirection
    {
        Incoming = 0,
        Outgoing = 1
    }

    public enum Position
    {
        Single = 0,
        First = 1,
        Normal = 2,
        Last = 3
    }

    public enum MessageType
    {
        Html = 0,
        Text = 1,
        Image = 2,
        Custom = 3
    }

    public class MessagePayload
    {
        // Definieren Sie Ihre Nachricht Payload-Eigenschaften hier, wenn nötig
    }
}
