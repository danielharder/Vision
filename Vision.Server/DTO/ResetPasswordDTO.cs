namespace Vision.Server.DTO
{
    public class ResetPasswordDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string NewPassword { get; set; }
    }
}