using Microsoft.AspNetCore.SignalR;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using WhisperChat.ChatServer.Models;
using WhisperChat.ChatServer.Services;

namespace WhisperChat.ChatServer.Hubs
{
    public class ChatHub : Hub
    {
        IMessageService _messageService;
        public ChatHub(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public async Task SendMessage(string message)
        {
            var messageModel = JsonSerializer.Deserialize<MessageModel>(message) ?? throw new Exception("Message could not be parsed");
            await _messageService.CreateMessage(messageModel);
            await Clients.Others.SendAsync("ReceiveMessage", messageModel);
        }

        public List<MessageModel> GetMessages(string senderId, string recipientId)
        {
            var messages =  _messageService.ReadMessagesByRecipientAsync(senderId, recipientId);
            return messages.ToList();
        }

        public async Task GetUsers()
        {
            var users = new List<UserModel>
            {
                new UserModel { Id = 1, Name = "Alice" },
                new UserModel { Id = 2, Name = "Bob" },
            };

            await Clients.Caller.SendAsync("ReceiveUsers", users);
        }
    }
}
