using Microsoft.AspNetCore.SignalR;

namespace ModelsApi.Hub;
using ModelsApi.Data;
using ModelsApi.Interfaces;
using ModelsApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

    public class ChatHub : Microsoft.AspNetCore.SignalR.Hub
    {
        private readonly ApplicationDbContext _context;
    
        public ChatHub(ApplicationDbContext context)
        {
            _context = context;
        }
    
        public async Task SendMessage(string content, int chatId)
        {
            var user = await _context.Managers.FindAsync(Context.UserIdentifier);
        
            var message = new Message
            {
                Content = content,
                SentAt = DateTime.Now,
                SenderId = user.EfAccountId,
                ChatId = chatId
            };
        
            _context.Messages.Add(message);
            await _context.SaveChangesAsync();
        
            await Clients.Group(chatId.ToString()).SendAsync("ReceiveMessage", message);
        }
    
        public async Task JoinConversation(int conversationId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, conversationId.ToString());
        }
    
        public async Task LeaveConversation(int conversationId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, conversationId.ToString());
        }
        }
        
        
    
        /*public async Task JoinChat(int annonceId)
        {
            var annonce = await _context.Annonces
                .Include(a => a.Chat)
                .SingleOrDefaultAsync(a => a.AnnonceId == annonceId);
            if (annonce != null)
            {
                var chatId = annonce.Chat.ChatId;
                await Groups.AddToGroupAsync(Context.ConnectionId, chatId.ToString());
    
                var messages = await _context.Messages
                    .Include(m => m.Chat)
                    .Where(m => m.Chat.ChatId == chatId)
                    .ToListAsync();
                await Clients.Caller.SendCoreAsync("chatHistory", messages.ToArray());
            }
        }

        public async Task SendMessage(int annonceId, string messageText)
        {
            var annonce = await _context.Annonces
                .Include(a => a.Chat)
                .SingleOrDefaultAsync(a => a.AnnonceId == annonceId);

            if (annonce != null)
            {
                var chatId = annonce.ChatId;

                var message = new Message
                {
                    Messages = messageText,
                    MessageId = chatId
                };

                _context.Messages.Add(message);
                await _context.SaveChangesAsync();

                await Clients.Group(chatId.ToString()).SendCoreAsync("ReceiveMessage", new object[] { message });
            }
        }
        /*
        public async Task SendMessage(int chatId, string message)
        {
            
    
            var chat = await _context.Chats.FindAsync(chatId);
            
            if(chat == null)
            {
                return;
            }
    
            var efManager = await GetEfManager();
    
    
            var chatManager = chat.Managers.FirstOrDefault(m => m.EfManagerId == efManager.EfManagerId);
    
            if (chatManager == null)
            {
                return;
            }
    
            var msg = new Message
            {
                Messages = message,
                Chat = chat
            };
            _context.Messages.Add(msg);
            await _context.SaveChangesAsync();
            await Clients.Group($"chat-{chatId}").SendCoreAsync("ReceiveMessage", msg);
        }*/
        
    }
    
    /*
    Her er noget kode som skal have inspiration fra
    
    namespace YourNamespace
    {
        public class ChatHub : Hub
        {
            private readonly YourDbContext _context;
    
            public ChatHub(YourDbContext context)
            {
                _context = context;
            }
    
            public async Task SendMessage(int chatId, string message)
            {
                var username = Context.User.Identity.Name;
    
                // Get the chat
                var chat = await _context.Chats
                    .Include(c => c.Messages)
                    .FirstOrDefaultAsync(c => c.ChatId == chatId);
    
                if (chat == null)
                {
                    return;
                }
    
                // Add the message
                chat.Messages.Add(new Message
                {
                    Messages = message
                });
    
                // Save the changes
                await _context.SaveChangesAsync();
    
                // Send the message to all clients in the chat room
                await Clients.Group(chatId.ToString()).SendAsync("ReceiveMessage", username, message);
            }
    
            public async Task JoinChat(int chatId)
            {
                // Add the user to the chat group
                await Groups.AddToGroupAsync(Context.ConnectionId, chatId.ToString());
    
                // Get the chat
                var chat = await _context.Chats.FindAsync(chatId);
    
                if (chat == null)
                {
                    return;
                }
    
                // Get the user's username
                var username = Context.User.Identity.Name;
    
                // Add the user to the chat's list of connected users
                chat.Managers.Add(await _context.Managers.FirstOrDefaultAsync(m => m.Email == username));
    
                // Save the changes
                await _context.SaveChangesAsync();
            }
    
            public async Task LeaveChat(int chatId)
            {
                // Remove the user from the chat group
                await Groups.RemoveFromGroupAsync(Context.ConnectionId, chatId.ToString());
    
                // Get the chat
                var chat = await _context.Chats.FindAsync(chatId);
    
                if (chat == null)
                {
                    return;
                }
    
                // Get the user's username
                var username = Context.User.Identity.Name;
    
                // Remove the user from the chat's list of connected users
                chat.Managers.Remove(await _context.Managers.FirstOrDefaultAsync(m => m.Email == username));
    
                // Save the changes
                await _context.SaveChangesAsync();
            }
        }
    }
    
    */
