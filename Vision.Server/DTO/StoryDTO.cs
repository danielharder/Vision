﻿namespace Vision.Server.Models
{
    public class StoryDTO
    {
        public Guid PK { get; set; }
        public Guid LaneId { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Status { get; set; } = null!;
        public DateTime CreationDate { get; set; }
        public DateTime ArchiveDate { get; set; }
    }
}
