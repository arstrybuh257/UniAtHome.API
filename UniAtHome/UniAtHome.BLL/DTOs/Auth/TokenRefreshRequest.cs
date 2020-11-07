namespace UniAtHome.BLL.DTOs.Auth
{
    public sealed class TokenRefreshRequest
    {
        public string AuthToken { get; set; }

        public string RefreshToken { get; set; }
    }
}
