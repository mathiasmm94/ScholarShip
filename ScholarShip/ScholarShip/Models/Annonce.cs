using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace ScholarShip.Models;

public class Annonce
{
    public int AnnonceId { get; set; }
    public double Price { get; set; }
    public string Titel { get; set; }
    public string Kategori { get; set; }
    public string Beskrivelse { get; set; }
    public string Studieretning { get; set; }
    public string BilledeSti { get; set; }
    [ForeignKey("ProfileId")]
    public string ProfileId { get; set; }
    public string Stand { get; set; }
    [ForeignKey("ChatId")]
    public int ChatId { get; set; }
    
    public Profil Profile { get; set; }
    public Chat Chat { get; set; }
}