﻿using System.ComponentModel.DataAnnotations;
using ScholarShip.Models;

namespace ModelsApi.Models.Entities
{
    public class EfManager
    {
        public long EfManagerId { get; set; }
        public long EfAccountId { get; set; }
        public EfAccount? Account { get; set; }
        [MaxLength(64)]
        public string? FirstName { get; set; }
        [MaxLength(32)]
        public string? LastName { get; set; }
        [MaxLength(254)]
        public string? Email { get; set; }
        
        public List<Chat> Chats { get; set; }
        public List<Annonce> Annoncer { get; set; }
    }
}
