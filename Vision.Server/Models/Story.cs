﻿namespace Vision.Server.Models
{
    public class Story
    {
        public Guid PK { get; set; }
<<<<<<< HEAD
        public Guid LanePK { get; set; }
=======
        public int Id { get; set; }
>>>>>>> parent of 2f1c67b (Sprint 2 complete!)
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Status { get; set; } = null!;
        public DateTime CreationDate { get; set; }
        public DateTime ArchiveDate { get; set; }
    }
}
