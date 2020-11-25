using Microsoft.Extensions.Options;
using System;
using System.Net.Http.Headers;
using System.Text;
using UniAtHome.BLL.Options;

namespace UniAtHome.BLL.Services.Zoom
{
    public class ZoomAdminClient : ZoomBaseClient
    {
        private const string ADMIN_AUTH_SCHEME = "Basic";

        public ZoomAdminClient(IOptions<ZoomClientConfig> options) 
            : base(GetAdminAuthScheme(options.Value))
        {
        }

        private static AuthenticationHeaderValue GetAdminAuthScheme(ZoomClientConfig config)
        {
            string tokenString = $"{config.ClientId}:{config.ClientSecret}";
            string tokenEncoded = Convert.ToBase64String(Encoding.UTF8.GetBytes(tokenString));
            return new AuthenticationHeaderValue(ADMIN_AUTH_SCHEME, tokenEncoded);
        }
    }
}
