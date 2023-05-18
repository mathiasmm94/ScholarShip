using ModelsApi.Hubs;
using ModelsApi.Models.Entities;

namespace ModelsApi.Models.Services;

public class UserChatRoom
{
    public int UserChatRoomId { get; set; }
    public int UserId { get; set; }
    public EfManager user { get; set; }
    
    public int ChatRoomId { get; set; }
    public ChatRoom ChatRoom { get; set; }
}