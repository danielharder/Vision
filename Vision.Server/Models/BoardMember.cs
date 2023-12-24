using System.ComponentModel.DataAnnotations;

namespace Vision.Server.Models
{
    public class BoardMember
    {
        public Guid BoardPK { get; set; }
        public Guid UserPK { get; set; }
        public string Role { get; set; } = null!;
    }
}
