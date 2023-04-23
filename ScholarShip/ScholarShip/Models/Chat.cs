using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace ScholarShip.Models;

public class Chat
{
    public int ChatId { get; set; }
    [ForeignKey("AnnonceID")]
    public int AnnonceID { get; set; }
    public int ProfilIdBuyer { get; set; }
    public int ProfilIdSeller { get; set; }

    public List<Message> Messages { get; set; }
    public List<IdentityUser> ProfilIdBuyers { get; set; }
    public List<IdentityUser> ProfilIdSellers { get; set; }
}