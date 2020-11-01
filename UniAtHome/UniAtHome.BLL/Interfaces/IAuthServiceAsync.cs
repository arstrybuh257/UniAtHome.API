using System.Threading.Tasks;
using UniAtHome.BLL.DTOs.Auth;

namespace UniAtHome.BLL.Interfaces
{
    public interface IAuthServiceAsync
    {
        Task<RegistrationResponse> RegisterAsync(RegistrationRequest request);

        Task<LoginResponse> LoginAsync(LoginRequest request);

        Task<TokenRefreshResponse> RefreshTokenAsync(TokenRefreshRequest request);

        Task<TokenRevokeResponse> RevokeTokenAsync(TokenRevokeRequest request);

        Task<UserInfoResponseDTO> GetUserInfoAsync(UserInfoRequestDTO request);
    }
}