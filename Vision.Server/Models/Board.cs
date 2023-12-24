using Microsoft.AspNetCore.Identity;

namespace Vision.Server.Models
{
    public class Board : IdentityUser
    {
        public Guid PK { get; set; }
<<<<<<< HEAD
        public Guid LanePK { get; set; }
=======
        public int Id { get; set; }
>>>>>>> parent of 2f1c67b (Sprint 2 complete!)
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime CreationDate { get; set; }
        public DateTime ArchiveDate { get; set; }
    }
}
