﻿namespace Vision.Server.Models
{
    public class TaskEntity
    {
        public Guid PK { get; set; }
        public int Id { get; set; }
        public Guid StoryPK { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Status { get; set; } = null!;
        public DateTime CreationDate { get; set; }
        public DateTime ArchiveDate { get; set; }
    }
}
