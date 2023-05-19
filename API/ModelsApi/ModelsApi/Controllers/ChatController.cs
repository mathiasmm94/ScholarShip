using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModelsApi.Data;
using ModelsApi.Models;
using ModelsApi.Models.Entities;

namespace ModelsApi.Controllers;
[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ChatController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ChatController(ApplicationDbContext context)
    {
        _context = context;
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