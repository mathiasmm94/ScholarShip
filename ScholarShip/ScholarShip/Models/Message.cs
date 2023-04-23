namespace ScholarShip.Models;

public class Message
{
    public int MessageID { get; set; }
    public string Messages { get; set; }
    public int ChatID { get; set; }

    public Chat Chats { get; set; }
}