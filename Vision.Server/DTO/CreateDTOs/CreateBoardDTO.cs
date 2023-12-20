namespace Vision.Server.DTO.CreateDTOs
{
    public class CreateBoardDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<BoardMemberDTO> BoardMembers { get; set; }
    }
}
