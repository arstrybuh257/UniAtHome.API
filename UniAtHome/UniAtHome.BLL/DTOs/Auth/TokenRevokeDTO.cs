namespace UniAtHome.BLL.DTOs.Auth
{
    public sealed class TokenRevokeDTO
    {
        public string Email { get; set; }

        public string RefreshToken { get; set; }
    }
}
