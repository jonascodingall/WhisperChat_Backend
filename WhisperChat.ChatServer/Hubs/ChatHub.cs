using Microsoft.AspNetCore.SignalR;
using WhisperChat.ChatServer.Models;

namespace WhisperChat.ChatServer.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(MessageModel message)
        {
            await Clients.All.SendAsync("ReceiveMessage", message);
        }

        public async Task GetMessages()
        {
            var messages = new List<MessageModel>
            {
                new MessageModel { Message= "Test1", Direction = MessageDirection.Incoming, Sender = "Joline", SentTime = "69", Position = Position.Single},
                new MessageModel { Message= "Test2", Direction = MessageDirection.Incoming, Sender = "Joline", SentTime = "69", Position = Position.Single},
            };
            await Clients.Caller.SendAsync("GetMessages", messages);
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
