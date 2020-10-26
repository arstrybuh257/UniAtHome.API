namespace UniAtHome.BLL.DTOs.Auth
{
    public sealed class TokenRevokeRequest
    {
        public string UserName { get; set; }

        public string RefreshToken { get; set; }
    }
}
