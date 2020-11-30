using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using UniAtHome.BLL.Exceptions;
using UniAtHome.BLL.Interfaces.Zoom;
using UniAtHome.DAL.Entities;
using UniAtHome.DAL.Interfaces;

namespace UniAtHome.BLL.Services.Zoom
{
    public class ZoomUserClient : ZoomClient
    {
        private const string USER_AUTH_SCHEME = "Bearer";

        private readonly IRepository<ZoomUser> zoomUsersRepository;

        private readonly string email;

        private readonly Lazy<IZoomAuthService> zoomAuthService;

        public ZoomUserClient(
            string userEmail,
            IRepository<ZoomUser> zoomUsersRepository,
            Lazy<IZoomAuthService> zoomAuthService)
        {
            this.email = userEmail;
            this.zoomUsersRepository = zoomUsersRepository;
            this.zoomAuthService = zoomAuthService;
        }

        protected override async Task<AuthenticationHeaderValue> GetAuthHeaderAsync()
        {
            ZoomUser userInfo = (await zoomUsersRepository.Find(u => u.User.Email == this.email)).FirstOrDefault();
            if (userInfo == null)
            {
                throw new ForbiddenException("The user didn't authorize in Zoom!");
            }
            string tokenString = userInfo.Token;
            return new AuthenticationHeaderValue(USER_AUTH_SCHEME, tokenString);
        }

        protected override async Task<HttpResponseMessage> SendAsync(
            string relativeUrl, 
            IDictionary<string, string> queryParams, 
            object body, 
            HttpMethod method)
        {
            var response = await base.SendAsync(relativeUrl, queryParams, body, method);
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                bool refreshed = await zoomAuthService.Value.RefreshAsync(this.email);
                if (refreshed)
                {
                    response = await base.SendAsync(relativeUrl, queryParams, body, method);
                }
            }
            return response;
        }
    }
}
