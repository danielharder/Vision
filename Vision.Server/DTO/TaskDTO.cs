namespace Vision.Server.Models
{
    public class TaskDTO
    {
        public Guid PK { get; set; }
        public Guid StoryID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
    }
}
