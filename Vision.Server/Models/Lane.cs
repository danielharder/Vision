namespace Vision.Server.Models
{
    public class Lane
    {
        public Guid PK { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ArchiveDate { get; set; }
    }
}
