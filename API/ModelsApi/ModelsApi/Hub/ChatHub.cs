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

    public async Task SendMessage(int chatRoomId, string senderName, string messageContent)
    {
        // Save the message to the database

        // Get the chat room and users from the database

        // Send the message to all connected clients in the chat room
        await Clients.Group(chatRoomId.ToString()).SendAsync("ReceiveMessage", senderName, messageContent);
    }

    public async Task JoinChatRoom(int chatRoomId)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, chatRoomId.ToString());
    }

    public async Task LeaveChatRoom(int chatRoomId)
    {
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, chatRoomId.ToString());
    }
}