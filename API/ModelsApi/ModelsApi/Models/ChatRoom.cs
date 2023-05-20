using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using ModelsApi.Models.Entities;

namespace ModelsApi.Models;

public class ChatRoom
{
    public int ChatRoomId { get; set; }
    public string Name { get; set; }
    
    public List<Annonce> Annonces { get; set; }
    public List<Message> Messages { get; set; }
    
}