using Microsoft.EntityFrameworkCore;
using WhisperChat.ChatServer.Models;

namespace WhisperChat.ChatServer.Data
{
    public class ChatContext : DbContext
    {
        public DbSet<MessageModel> Messages { get; set; }
        public ChatContext(DbContextOptions<ChatContext> options) : base(options) { }
    }
}
