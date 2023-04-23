using System.ComponentModel.DataAnnotations.Schema;

namespace ScholarShip.Models;

public class Message
{
    public int MessageId { get; set; }
    public string Messages { get; set; }
    [ForeignKey("ChatId")]
    public int ChatId { get; set; }

    public Chat Chat { get; set; }
}