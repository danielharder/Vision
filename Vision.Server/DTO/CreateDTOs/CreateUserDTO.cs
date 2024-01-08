namespace Vision.Server.DTO.CreateDTOs
{
    public class CreateUserDTO
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; }
        public string Password { get; set; }
        public string Description { get; set; } = null!;
    }
}
