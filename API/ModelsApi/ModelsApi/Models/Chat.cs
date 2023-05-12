using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using ModelsApi.Models.Entities;
using ModelsApi.Models.Services;

namespace ModelsApi.Models;

public class Chat
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; }
    
    public List<Participant> Participants { get; set; }
    public List<Message> Messages { get; set; }

}