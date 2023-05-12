using System.ComponentModel.DataAnnotations.Schema;
using ModelsApi.Models.Entities;

namespace ModelsApi.Models;

public class Message
{
    public int MessageId { get; set; }
    public string Content { get; set; }
    public DateTime SentAt { get; set; }
    
    public int SenderId { get; set; }
    public EfManager EfManager { get; set; }
    
    public int ChatId { get; set; }
    public Chat Chat { get; set; }
}