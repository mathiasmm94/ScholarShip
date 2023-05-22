using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModelsApi.Data;
using ModelsApi.Models;
using ModelsApi.Models.Entities;
using System.Text.Json;
using System.Text.Json.Serialization;
using ModelsApi.Models.DTOs;

namespace ModelsApi.Controllers;


[Route("api/[controller]")]
[ApiController]
public class ChatController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ChatController(ApplicationDbContext context)
    {
        _context = context;
    }
    
    
    [HttpGet("rooms/{ChatRoomId}/messages")]
    public async Task<ActionResult<List<MessageDTO>>> GetChatRoomMessages(int ChatRoomId)
    {
        var messages = await _context.Messages
            .Include(m => m.EfManager)
            .Where(m => m.ChatRoomId == ChatRoomId)
            .ToListAsync();

        var messageDTOs = messages.Select(message => new MessageDTO
        {
            MessageId = message.MessageId,
            Content = message.Content,
            FirstName = message.EfManager?.FirstName ?? string.Empty
        }).ToList();

        return Ok(messageDTOs);
    }
    [HttpGet("annonce/{annonceId}/owner")]
    public async Task<ActionResult<EfManager>> GetAdOwner(int annonceId)
    {
        var annonce = await _context.Annonces.FindAsync(annonceId);

        if (annonce == null)
        {
            return NotFound();
        }

        var options = new JsonSerializerOptions
        {
            ReferenceHandler = ReferenceHandler.Preserve,
        };

        var owner = await _context.Managers.FindAsync(annonce.EfManagerId);

        if (owner == null)
        {
            return NotFound();
        }

        return Ok(JsonSerializer.Serialize(owner, options));
    }
    
    [HttpPost("rooms/{roomId}/messages")]
    public async Task<ActionResult<Message>> SendMessage(int roomId, [FromBody] Message message)
    {
        var userId = new EfManager();

        // Set the message properties
        message.EfManagerId = userId.EfAccountId;
        message.ChatRoomId = roomId;
        message.TimeStamp = DateTime.UtcNow;

        // Save the message to the database
        _context.Messages.Add(message);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetChatRoomMessages), new { roomId }, message);
    }
}