namespace UniAtHome.BLL.DTOs.Auth
{
    public sealed class TokenRefreshRequestDTO
    {
        public string AuthToken { get; set; }

        public string RefreshToken { get; set; }
    }
}
