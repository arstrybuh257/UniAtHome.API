namespace UniAtHome.BLL.DTOs.Auth
{
    public sealed class TokenRefreshResponseDTO
    {
        public string Token { get; set; }

        public string RefreshToken { get; set; }
    }
}
