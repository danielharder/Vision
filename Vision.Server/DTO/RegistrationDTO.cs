namespace Vision.Server.DTO.CreateDTOs
{
    public class RegistrationDTO
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; }
        public string Description { get; set; } = null!;
        public string password { get; set; }
    }
}