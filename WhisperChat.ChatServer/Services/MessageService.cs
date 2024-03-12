using WhisperChat.ChatServer.Data.Repos;
using WhisperChat.ChatServer.Models;

namespace WhisperChat.ChatServer.Services
{
    public class MessageService : IMessageService
    {
        private readonly IRepository<MessageModel> _repository;
        public MessageService(IRepository<MessageModel> repository)
        {
            _repository = repository;
        }
        public async Task CreateMessage(MessageModel messageModel)
        {
            await _repository.AddAsync(messageModel);
            await _repository.SaveChangesAsync();
        }

        public IEnumerable<MessageModel> ReadMessagesByRecipientAsync(string senderId, string recipientId)
        {
            return _repository.Find(message => (message.Sender == senderId && message.RecipientId == recipientId) || (message.Sender == recipientId && message.RecipientId == senderId));
        }
    }
}
