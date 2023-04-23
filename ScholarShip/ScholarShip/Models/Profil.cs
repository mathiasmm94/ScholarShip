using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace ScholarShip.Models;

public class Profil : IdentityUser
{
    public string ForNavn { get; set; }
    public string EfterNavn { get; set; }
    [ForeignKey("ChatId")]
    public int ChatId { get; set; }
    [ForeignKey("AnnonceId")]
    public int AnnonceId { get; set; }
        
    public List<Chat> Chats { get; set; }
    public List<Annonce> Annoncer { get; set; }
}