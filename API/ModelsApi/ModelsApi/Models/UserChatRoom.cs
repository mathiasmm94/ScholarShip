using ModelsApi.Hubs;
using ModelsApi.Models.Entities;

namespace ModelsApi.Models.Services;

public class UserChatRoom
{
    public int UserChatRoomId { get; set; }
    
    public long EfManagerId { get; set; }
    public EfManager EfManager { get; set; }
    
    public int ChatRoomId { get; set; }
    public ChatRoom ChatRoom { get; set; }
}