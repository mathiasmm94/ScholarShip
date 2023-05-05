using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using ModelsApi.Models.Entities;

namespace ModelsApi.Models;

public class Chat
{
    public int ChatId { get; set; }
    
    public List<Annonce> Annonces { get; set; }
    public List<Message> Messages { get; set; }
    public List<EfAccount> Profils { get; set; }


}