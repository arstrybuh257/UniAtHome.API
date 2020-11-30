using Microsoft.Extensions.Options;
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
            IOptions<ZoomClientConfig> options,
            UserRepository usersRepository,
            IRepository<ZoomUser> zoomUsersRepository)
        {
            this.zoomClient = zoomClient;
            this.options = options.Value;
            this.usersRepository = usersRepository;
            this.zoomUsersRepository = zoomUsersRepository;
        }

        public async Task<bool> AuthorizeAsync(string email, string code)
        {
            using var response = await zoomClient.PostAsync(
                "oauth/token",
                new Dictionary<string, string> {
                    { "grant_type", "authorization_code" },
                    { "code", code },
                    { "redirect_uri", options.OAuthRedirectUrl }
                },
                null);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                string json = await response.Content.ReadAsStringAsync();
                ExtractAuthInfoFromTokenResponseBody(json, out string token, out string refresh);
                await SaveZoomAuthorizationTokensAsync(email, token, refresh);

                return true;
            }
            return false;
        }

        private static void ExtractAuthInfoFromTokenResponseBody(string json, out string token, out string refresh)
        {
            JObject bodyObject = JObject.Parse(json);
            token = bodyObject["access_token"].Value<string>();
            refresh = bodyObject["refresh_token"].Value<string>();
        }

        private async Task SaveZoomAuthorizationTokensAsync(string email, string token, string refresh)
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

        public async Task<bool> RefreshAsync(string email)
        {
            User user = await usersRepository.FindByEmailAsync(email);
            ZoomUser zoomUser = (await zoomUsersRepository
                .Find(u => user.Id == u.UserId))
                .FirstOrDefault();
            if (zoomUser == null)
            {
                return false;
            }

            string refreshToken = zoomUser.RefreshToken;

            using var response = await zoomClient.PostAsync(
                "oauth/token",
                new Dictionary<string, string> {
                    { "grant_type", "refresh_token" },
                    { "refresh_token", refreshToken }
                },
                null);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                string json = await response.Content.ReadAsStringAsync();
                ExtractAuthInfoFromTokenResponseBody(json, out string token, out string refresh);
                await SaveZoomAuthorizationTokensAsync(email, token, refresh);

                return true;
            }
            return false;

        }

        public void RevokeAsync(string email)
        {
            // TODO: It looks like we don't need it at all
            throw new NotImplementedException();
        }
    }
}
