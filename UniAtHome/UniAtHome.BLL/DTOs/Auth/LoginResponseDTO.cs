namespace UniAtHome.BLL.DTOs.Auth
{
    public sealed class LoginResponseDTO
    {
        public string Token { get; set; }

        public string RefreshToken { get; set; }

        public string Email { get; set; }
    }
}
