namespace Pustok.Buisness.Dtos.UserDtos
{
    public class RegisterDto
    {
        public string Username { get; set; } = string.Empty;
        public string Fullname { get; set; }= string.Empty;
        public string Email { get; set; }   = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
