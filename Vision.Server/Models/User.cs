using Microsoft.AspNetCore.Identity;
using System.IO.Compression;

namespace Vision.Server.Models
{
    public class User : IdentityUser
    {
        public Guid PK { get; set; }
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; }
        public string Password { get; set; }
        public string Description { get; set; } = null!;
        public DateTime CreationDate { get; set; }
        public DateTime ArchiveDate { get; set; }
    }
}
