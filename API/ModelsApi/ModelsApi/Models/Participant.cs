using System.ComponentModel.DataAnnotations;
using ModelsApi.Models.Entities;

namespace ModelsApi.Models.Services;

public class Participant
{
    [Key]
    public int ParticipantId { get; set; }
    
    public int UserId { get; set; }
    public EfManager EfManager { get; set; }
    
    public int ConversationId { get; set; }
    public Chat Chat { get; set; }
}