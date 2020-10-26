namespace UniAtHome.BLL.DTOs.Auth
{
    public sealed class TokenRevokeRequest
    {
        public string Email { get; set; }

        public string RefreshToken { get; set; }
    }
}
