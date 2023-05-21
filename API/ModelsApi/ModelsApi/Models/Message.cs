using System.ComponentModel.DataAnnotations.Schema;
using ModelsApi.Models.Entities;

namespace ModelsApi.Models;

public class Message
{
    public int MessageId { get; set; }
    public string Content { get; set; }
    public DateTime TimeStamp { get; set; }
    public int ChatRoomId { get; set; }
    public ChatRoom ChatRoom { get; set; }
    public long EfManagerId { get; set; }
    public EfManager EfManager { get; set; }

   
    
}