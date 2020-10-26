using System.Collections.Generic;
using System.Threading.Tasks;
using UniAtHome.BLL.DTOs.UserRequests;

namespace UniAtHome.BLL.Interfaces
{
    public interface IAuthServiceAsync
    {
        Task<IEnumerable<object>> TryRegisterAndReturnErrorsAsync(RegistrationRequest registerModel);

        Task<object> GetAuthTokenAsync(LoginRequest loginModel);

        Task<object> RefreshTokenAsync();
    }
}