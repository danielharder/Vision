using System.IO.Compression;

namespace Vision.Server.Models
{
    public class UserUpdateDTO
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}
