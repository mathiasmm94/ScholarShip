using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace ScholarShip.Models;

public class Annonce
{
    public int AnnonceID { get; set; }
    public double Price { get; set; }
    public string Titel { get; set; }
    public string Kategori { get; set; }
    public string Beskrivelse { get; set; }
    public string Studieretning { get; set; }
    public string BilledeSti { get; set; }
    public string ProfilId { get; set; }
    public string Stand { get; set; }
    public int ChatId { get; set; }

    
    public IdentityUser Profiler { get; set; }
    public Chat Chats { get; set; }
}