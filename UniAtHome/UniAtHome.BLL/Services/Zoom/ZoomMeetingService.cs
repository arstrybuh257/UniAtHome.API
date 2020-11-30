using System;
using System.Net;
using System.Threading.Tasks;
using UniAtHome.BLL.DTOs.Zoom;
using UniAtHome.BLL.Exceptions;
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

        public async Task<ZoomMeetingDTO> CreateMeetingAsync(ZoomMeetingCreateDTO options, string ownerEmail)
        {
            ZoomUserClient zoomClient = GetZoomClientForUser(ownerEmail);
            IZoomUserService userService = new ZoomUserService(zoomClient);
            ZoomUserInfoDTO user = await userService.GetUserInfoAsync();

            var response = await zoomClient.PostDeserializedAsync<ZoomMeetingDTO>(
                    $"v2/users/{user.Id}/meetings", null, options);
            if (response.HttpMessage.StatusCode != HttpStatusCode.Created)
            {
                throw new BadRequestException(await response.HttpMessage.Content.ReadAsStringAsync());
            }

            return response.Body;
        }

        private ZoomUserClient GetZoomClientForUser(string userEmail)
        {
            return new ZoomUserClient(userEmail, zoomUsersRepository, zoomAuthService);
        }

        public async Task<ZoomMeetingDTO> GetMeetingInfoAsync(long meetingId, string userEmail)
        {
            ZoomUserClient zoomClient = GetZoomClientForUser(userEmail);
            var response = await zoomClient
                .GetDeserializedAsync<ZoomMeetingDTO>($"v2/meetings/{meetingId}");

            if (response.HttpMessage.StatusCode == HttpStatusCode.OK)
            {
                return response.Body;
            }
            if (response.HttpMessage.StatusCode == HttpStatusCode.NotFound)
            {
                throw new NotFoundException("Meeting doesn't exist!");
            }
            if (response.HttpMessage.StatusCode == HttpStatusCode.BadRequest)
            {
                throw new ForbiddenException("Can't access meeting info!");
            }
            throw new BadRequestException(await response.HttpMessage.Content.ReadAsStringAsync());
        }

        public async Task EditMeetingAsync(long meetingId, ZoomMeetingEditDTO meetingDTO, string userEmail)
        {
            ZoomUserClient zoomClient = GetZoomClientForUser(userEmail);
            var response = await zoomClient.PatchAsync(
                $"v2/meetings/{meetingId}", null, meetingDTO);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                throw new NotFoundException("Meeting doesn't exist or is expired!");
            }
        }

        public async Task DeleteMeetingAsync(long meetingId, string userEmail)
        {
            ZoomUserClient zoomClient = GetZoomClientForUser(userEmail);
            var response = await zoomClient.DeleteAsync($"v2/meetings/{meetingId}");
            switch(response.StatusCode)
            {
                case HttpStatusCode.NoContent: return;
                case HttpStatusCode.BadRequest: 
                    throw new BadRequestException("Can't delete the meeting!");
                case HttpStatusCode.NotFound:
                    throw new NotFoundException("Meeting doesn't exist or is expired!");
            }
        }
    }
}
