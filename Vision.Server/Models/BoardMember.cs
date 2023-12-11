using System.ComponentModel.DataAnnotations;

namespace Vision.Server.Models
{
    public class BoardMember
    {
        public int BoardId { get; set; }
        public int UserId { get; set; }
        public string Role { get; set; } = null!;
    }
}
