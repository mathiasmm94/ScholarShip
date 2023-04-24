using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace ScholarShip.Models;

public class Chat
{
    public int ChatId { get; set; }
    
    public List<Annonce> Annonces { get; set; }
    public List<Message> Messages { get; set; }
    public List<Profil> Profils { get; set; }


}