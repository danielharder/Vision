namespace Vision.Server.Models
{
    public class Log
    {
        public Guid PK { get; set; }
        public Guid EntityPK { get; set; }
        public string EntityType { get; set; } = null!;
        public int EntityId { get; set; }
        public string Action { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime Timestamp { get; set; }
    }
}
