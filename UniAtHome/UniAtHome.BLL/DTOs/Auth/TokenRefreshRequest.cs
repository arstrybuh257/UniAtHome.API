namespace UniAtHome.BLL.DTOs.Auth
{
    public sealed class TokenRefreshRequest
    {
        public string UserName { get; set; }

        public string RefreshToken { get; set; }
    }
}
