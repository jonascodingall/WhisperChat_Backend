using System;
using WhisperChat.ChatServer.Models;

namespace WhisperChat.ChatServer.Services
{
    public interface IMessageService
    {
        Task CreateMessage(MessageModel messageModel);
        public IEnumerable<MessageModel> ReadMessagesByRecipientAsync(string senderId, string recipientId);
    }
}
