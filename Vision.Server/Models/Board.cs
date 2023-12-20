namespace Vision.Server.Models
{
    public class Board
    {
        public Guid PK { get; set; }
        public int Id { get; set; }
        public Guid LanePK { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime CreationDate { get; set; }
        public DateTime ArchiveDate { get; set; }
    }
}
