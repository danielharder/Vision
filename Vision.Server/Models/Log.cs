namespace Vision.Server.Models
{
    public class Log
    {
        public Guid PK { get; set; }
        public Guid EntityPK { get; set; }
        public string EntityType { get; set; }
        public int EntityId { get; set; }
        public string Action { get; set; }
        public string Description { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
