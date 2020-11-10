using System.Threading.Tasks;
using UniAtHome.BLL.DTOs.Auth;

namespace UniAtHome.BLL.Interfaces
{
    public interface IAuthService
    {
        Task RegisterAdminAsync(AdminRegistrationDTO request);

        Task RegisterUniversityAdminAsync(UniversityAdminRegistrationDTO request);

        Task RegisterTeacherAsync(TeacherRegistrationDTO request);

        Task RegisterStudentAsync(StudentRegistrationDTO request);

        Task<LoginResponseDTO> LoginAsync(LoginRequestDTO request);

        Task<TokenRefreshResponseDTO> RefreshTokenAsync(TokenRefreshRequestDTO request);

        Task RevokeTokenAsync(TokenRevokeDTO request);

        Task<UserInfoResponseDTO> GetUserInfoAsync(string email);
    }
}