using System.Threading.Tasks;
using UniAtHome.BLL.DTOs.Auth;

namespace UniAtHome.BLL.Interfaces
{
    public interface IAuthService
    {
        Task RegisterAsync(RegistrationDTO request);

        Task<LoginResponseDTO> LoginAsync(LoginRequestDTO request);

        Task<TokenRefreshResponseDTO> RefreshTokenAsync(TokenRefreshRequestDTO request);

        Task RevokeTokenAsync(TokenRevokeDTO request);

        Task<UserInfoResponseDTO> GetUserInfoAsync(string email);
    }
}