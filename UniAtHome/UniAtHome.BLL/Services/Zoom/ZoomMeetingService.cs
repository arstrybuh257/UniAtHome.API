using System;
using System.Net;
using System.Threading.Tasks;
using UniAtHome.BLL.DTOs.Zoom;
using UniAtHome.BLL.Interfaces.Zoom;
using UniAtHome.DAL.Entities;
using UniAtHome.DAL.Interfaces;

namespace UniAtHome.BLL.Services.Zoom
{
    public class ZoomMeetingService
    {
        private readonly Lazy<IZoomAuthService> zoomAuthService;

        private readonly IRepository<ZoomUser> zoomUsersRepository;

        public ZoomMeetingService(Lazy<IZoomAuthService> zoomAuthService, IRepository<ZoomUser> zoomUsersRepository)
        {
            this.zoomAuthService = zoomAuthService;
            this.zoomUsersRepository = zoomUsersRepository;
        }

        public async Task<ZoomMeetingCreatedDTO> CreateMeetingAsync(ZoomMeetingCreateDTO options, string ownerEmail)
        {
            ZoomUserClient zoomClient = new ZoomUserClient(ownerEmail, zoomUsersRepository, zoomAuthService);
            IZoomUserService userService = new ZoomUserService(zoomClient);
            ZoomUserInfoDTO user = await userService.GetUserInfoAsync();

            var response = await zoomClient
                .PostDeserializedAsync<ZoomMeetingCreatedDTO>(
                    $"v2/users/{user.Id}/meetings", null, options);
            if (response.HttpMessage.StatusCode != HttpStatusCode.Created)
            {
                return null;
            }

            return response.Body;
        }
    }
}
