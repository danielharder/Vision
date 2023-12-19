using Vision.Server.DTO;

namespace Vision.Server.Models
{
    public class BoardDTO
    {
        public Guid PK { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<BoardMemberDTO> BoardMembers { get; set; }
    }
}
