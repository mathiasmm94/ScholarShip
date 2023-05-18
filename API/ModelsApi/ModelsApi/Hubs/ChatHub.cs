using Microsoft.AspNetCore.SignalR;
using ModelsApi.Data;
using ModelsApi.Interfaces;
using ModelsApi.Models;

namespace ModelsApi.Hubs;

public class ChatHub : Hub
{
    private readonly ApplicationDbContext _context;

    public ChatHub(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task SendMessage(int chatRoomId, string messageContent)
    {
        var user = await _context.Managers.FindAsync(Context.UserIdentifier);

        var message = new Message
        {
            EfManagerId = user.EfManagerId,
            ChatRoomId = chatRoomId,
            Content = messageContent,
            TimeStamp = DateTime.Now
        };

        _context.Messages.Add(message);
        await _context.SaveChangesAsync();

        await Clients.Group(chatRoomId.ToString()).SendAsync("Receive Message", message);
    }

    public async Task JoinChatRoom(int chatRoomId)
    {
        // Add the user to the chat room group
        await Groups.AddToGroupAsync(Context.ConnectionId, chatRoomId.ToString());
    }

    public async Task LeaveChatRoom(int chatRoomId)
    {
        // Remove the user from the chat room group
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, chatRoomId.ToString());
    }

    public override async Task OnConnectedAsync()
    {
        // Perform any necessary tasks when a client connects

        await base.OnConnectedAsync();
    }

    public override async Task OnDisconnectedAsync(Exception exception)
    {
        // Perform any necessary tasks when a client disconnects

        await base.OnDisconnectedAsync(exception);
    }
}