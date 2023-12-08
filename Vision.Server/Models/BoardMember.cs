namespace Vision.Server.Models
{
    public class BoardMember
    {
        public Guid PK { get; set; }
        public int BoardId { get; set; }
        public int UserId { get; set; }
        public string Role { get; set; }
    }
}
