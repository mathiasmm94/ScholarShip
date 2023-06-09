using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using ModelsApi.Models.Entities;

namespace ModelsApi.Models;

public class Annonce
{
    public int AnnonceId { get; set; }
    public double Price { get; set; }
    public string Titel { get; set; }
    public string Kategori { get; set; }
    public string Beskrivelse { get; set; }
    public string Studieretning { get; set; }
    public string BilledeSti { get; set; }
    public bool? CheckBoxValue { get; set; }
    public int? NumberOfWeeks { get; set; }
    
    [ForeignKey("EfManagerId")]
    public long EfManagerId { get; set; }
    
    public string Stand { get; set; }
    
    [ForeignKey("ChatRoomId")]
    public int ChatRoomId { get; set; }
    
    public EfManager Manager { get; set; }
    public ChatRoom ChatRoom { get; set; }
}