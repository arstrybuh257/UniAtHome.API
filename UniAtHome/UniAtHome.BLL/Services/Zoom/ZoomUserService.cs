using System.Threading.Tasks;
using UniAtHome.BLL.DTOs.Zoom;
using UniAtHome.BLL.Interfaces.Zoom;

namespace UniAtHome.BLL.Services.Zoom
{
    public class ZoomUserService : IZoomUserService
    {
        private readonly ZoomClient userClient;

        public ZoomUserService(ZoomUserClient userClient)
        {
            this.userClient = userClient;
        }

        public async Task<ZoomUserInfoDTO> GetUserInfoAsync()
        {
            var response = await userClient
                .GetDeserializedAsync<ZoomUserInfoDTO>("v2/users/me", null);
            ZoomUserInfoDTO userInfo = response.Body;
            return userInfo;
        }
    }
}
