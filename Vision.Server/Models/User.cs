using System.IO.Compression;

namespace Vision.Server.Models
{
    public class User
    {
        public Guid PK { get; set; }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ArchiveDate { get; set; }
    }
}
