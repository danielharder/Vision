namespace Vision.Server.Models
{
    public class Story
    {
        public Guid PK { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ArchiveDate { get; set; }
    }
}
