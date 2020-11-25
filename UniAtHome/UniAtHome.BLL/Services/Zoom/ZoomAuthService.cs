using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using UniAtHome.BLL.Interfaces.Zoom;
using UniAtHome.BLL.Options;
using UniAtHome.DAL.Entities;
using UniAtHome.DAL.Interfaces;
using UniAtHome.DAL.Repositories;

namespace UniAtHome.BLL.Services.Zoom
{
    public class ZoomAuthService : IZoomAuthService
    {
        private readonly ZoomAdminClient zoomClient;

        private readonly ZoomClientConfig options;

        private readonly UserRepository usersRepository;

        private readonly IRepository<ZoomUser> zoomUsersRepository;

        public ZoomAuthService(
            ZoomAdminClient zoomClient,
            ZoomClientConfig options,
            UserRepository usersRepository,
            IRepository<ZoomUser> zoomUsersRepository)
        {
            this.zoomClient = zoomClient;
            this.options = options;
            this.usersRepository = usersRepository;
            this.zoomUsersRepository = zoomUsersRepository;
        }

        public async Task<bool> AuthorizeAsync(string email, string code)
        {
            using var response = await zoomClient.PostAsync(
                "oauth/token",
                new Dictionary<string, string> {
                    { "grantType", "authorization_code" },
                    { "code", code },
                    { "redirect_uri", options.OAuthRedirectUrl }
                },
                null);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                string json = await response.Content.ReadAsStringAsync();
                JObject bodyObject = JObject.Parse(json);
                string token = bodyObject["access_token"].Value<string>();
                string refresh = bodyObject["refresh_token"].Value<string>();

                await SaveZoomAuthorizationTokens(email, token, refresh);

                return true;
            }
            return false;
        }

        private async Task SaveZoomAuthorizationTokens(string email, string token, string refresh)
        {
            User user = await usersRepository.FindByEmailAsync(email);
            ZoomUser zoomCreds = (await zoomUsersRepository
                .Find(u => u.UserId == user.Id))
                .FirstOrDefault();

            if (zoomCreds == null)
            {
                await zoomUsersRepository.AddAsync(new ZoomUser
                {
                    UserId = user.Id,
                    Token = token,
                    RefreshToken = refresh
                });
            }
            else
            {
                zoomCreds.Token = token;
                zoomCreds.RefreshToken = refresh;
                zoomUsersRepository.Update(zoomCreds);
            }
            await zoomUsersRepository.SaveChangesAsync();
        }

        public void Refresh(string email)
        {

        }

        public void Revoke(string email)
        {
            throw new NotImplementedException();
        }
    }
}
