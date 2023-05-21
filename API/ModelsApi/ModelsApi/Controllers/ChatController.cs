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

    [HttpPost]
    public async Task<IActionResult> PostChatId(ChatRoomDTO chatRoom)
    {
        if (_context.ChatRooms == null)
            return Problem("No connection");

        ChatRoom chat = new ChatRoom
        {
            ChatRoomId = chatRoom.ChatRoomId
        };
         _context.ChatRooms.Add(chat);
         await _context.SaveChangesAsync();

         return Ok(chat);
    }
    
    

    [HttpGet("rooms")]
    public async Task<ActionResult<List<ChatRoom>>> GetChatRooms()
    {
        // Retrieve all chat rooms
        var chatRooms = await _context.ChatRooms.ToListAsync();
        return Ok(chatRooms);
    }
    
    [HttpGet("rooms/{roomId}")]
    public async Task<ActionResult<ChatRoom>> GetChatRoom(int roomId)
    {
        // Retrieve a specific chat room by ID
        var chatRoom = await _context.ChatRooms.FindAsync(roomId);

        if (chatRoom == null)
        {
            return NotFound();
        }

        return Ok(chatRoom);
    }
    
    [HttpGet("rooms/{roomId}/messages")]
    public async Task<ActionResult<List<Message>>> GetChatRoomMessages(int roomId)
    {
        // Retrieve messages for a specific chat room
        var messages = await _context.Messages
            .Where(m => m.ChatRoomId == roomId)
            .ToListAsync();

        return Ok(messages);
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