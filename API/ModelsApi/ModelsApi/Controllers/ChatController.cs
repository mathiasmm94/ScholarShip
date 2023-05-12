using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using ModelsApi.Data;
using ModelsApi.Models;

namespace ModelsApi.Controllers;
using ModelsApi.Hub;

/*
[ApiController]
[Route("api/chats")]
public class ChatController : ControllerBase
{
    private readonly IHubContext<ChatHub> _hubContext;
    private readonly ApplicationDbContext _context;

    public ChatController(IHubContext<ChatHub> hubContext, ApplicationDbContext context)
    {
        _hubContext = hubContext;
        _context = context;
    }

    [HttpPost("{annonceId}/join")]
    public async Task<IActionResult> JoinChat(int annonceId)
    {
        await _hubContext.Clients.All.SendAsync("joinChat", annonceId);
        return Ok();
    }
    
    [HttpPost("{annonceId}/send")]
    public async Task<IActionResult> SendMessage(int annonceId, [FromBody] string messageText)
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

            await _hubContext.Clients.Group(chatId.ToString()).SendCoreAsync("ReceiveMessage", new object[] { message });
        }

        return Ok();
    }
    
}*/