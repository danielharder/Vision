namespace Vision.Server.Models
{
    public class Board
    {
        public Guid PK { get; set; }
        public int id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ArchiveDate { get; set; }
    }
}
