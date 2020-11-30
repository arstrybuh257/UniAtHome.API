using Microsoft.Extensions.Options;
using System;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using UniAtHome.BLL.Options;

namespace UniAtHome.BLL.Services.Zoom
{
    public class ZoomAdminClient : ZoomClient
    {
        private const string ADMIN_AUTH_SCHEME = "Basic";

        private readonly ZoomClientConfig config;

        public ZoomAdminClient(IOptions<ZoomClientConfig> options)
        {
            this.config = options.Value;
        }

        protected override Task<AuthenticationHeaderValue> GetAuthHeaderAsync()
        {
            string tokenString = $"{config.ClientId}:{config.ClientSecret}";
            string tokenEncoded = Convert.ToBase64String(Encoding.UTF8.GetBytes(tokenString));
            return Task.FromResult(new AuthenticationHeaderValue(ADMIN_AUTH_SCHEME, tokenEncoded));
        }
    }
}
