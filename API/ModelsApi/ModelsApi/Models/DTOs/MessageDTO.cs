using ModelsApi.Models.Entities;

namespace ModelsApi.Models.DTOs
{
    public class MessageDTO
    {
        public int MessageId { get; set; }
        public string Content { get; set; }
        public string FirstName { get; set; }
    }
    
}