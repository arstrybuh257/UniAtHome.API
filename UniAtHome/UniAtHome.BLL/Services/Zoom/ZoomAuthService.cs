using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using UniAtHome.BLL.Interfaces.Zoom;
using UniAtHome.BLL.Options;

namespace UniAtHome.BLL.Services.Zoom
{
    public class ZoomAuthService : IZoomAuthService
    {
        private ZoomAdminClient zoomClient;

        private ZoomClientConfig options;

        public ZoomAuthService(ZoomAdminClient zoomClient, ZoomClientConfig options)
        {
            this.zoomClient = zoomClient;
            this.options = options;
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

                // TODO: save to db

                return true;
            }
            return false;
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
