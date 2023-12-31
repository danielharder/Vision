﻿namespace Vision.Server.Models
{
    public class Lane
    {
        public Guid PK { get; set; }
        public int Id { get; set; }
        public Guid BoardPK { get; set; }
        public string Name { get; set; } = null!;
        public DateTime CreationDate { get; set; }
        public DateTime ArchiveDate { get; set; }
    }
}
