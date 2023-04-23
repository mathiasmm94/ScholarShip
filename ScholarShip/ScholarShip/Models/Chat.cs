using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace ScholarShip.Models;

public class Chat
{
    public int ChatId { get; set; }
    [ForeignKey("AnnonceId")]
    public int AnnonceId { get; set; }
    [ForeignKey("ProfilBuyerId")]
    public string ProfilBuyerId { get; set; }
    [ForeignKey("ProfilSellerId")]
    public string ProfilSellerId { get; set; }

    public int MessageId { get; set; }
    
    public List<Annonce> Annonces { get; set; }
    public List<Message> Messages { get; set; }
    public List<IdentityUser> ProfilIdBuyers { get; set; }
    public List<IdentityUser> ProfilIdSellers { get; set; }

}