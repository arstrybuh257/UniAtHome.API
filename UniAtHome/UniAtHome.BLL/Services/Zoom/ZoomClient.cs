using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using UniAtHome.BLL.DTOs.Zoom;

namespace UniAtHome.BLL.Services.Zoom
{
    public abstract class ZoomClient
    {
        private readonly HttpClient client;

        private static readonly Uri zoomApiUrl = new Uri(@"https://zoom.us/");

        protected ZoomClient()
        {
            client = new HttpClient();
        }

        protected abstract Task<AuthenticationHeaderValue> GetAuthHeaderAsync();

        protected virtual async Task<HttpResponseMessage> SendAsync(
            string relativeUrl,
            IDictionary<string, string> queryParams,
            object body,
            HttpMethod method)
        {
            HttpRequestMessage request = await BuildRequestAsync(
                relativeUrl, queryParams, body, method);

            return await client.SendAsync(request);
        }

        public Task<HttpResponseMessage> GetAsync(
            string relativeUrl,
            IDictionary<string, string> queryParams = null)
        {
            return this.SendAsync(relativeUrl, queryParams, null, HttpMethod.Get);
        }

        private async Task<HttpRequestMessage> BuildRequestAsync(
            string relativeUrl, 
            IDictionary<string, string> queryParams, 
            object body,
            HttpMethod httpMethod)
        {
            string requestUrl = GetAbsoluteUrlWithParams(relativeUrl, queryParams);

            string bodyAsJson = JsonConvert.SerializeObject(body, GetContentSerializationSettings());
            HttpContent content = new StringContent(
                content: bodyAsJson,
                encoding: Encoding.UTF8,
                mediaType: MediaTypeNames.Application.Json);

            var request = new HttpRequestMessage(httpMethod, requestUrl);
            request.Content = content;
            request.Headers.Authorization = await GetAuthHeaderAsync();
            return request;
        }

        private static string GetAbsoluteUrlWithParams(
            string relativeUrl,
            IDictionary<string, string> queryParams)
        {
            string absoluteUrl = new Uri(zoomApiUrl, relativeUrl).ToString();
            if (queryParams?.Any() ?? false)
            {
                return QueryHelpers.AddQueryString(absoluteUrl, queryParams);
            }
            return absoluteUrl;
        }

        public async Task<ZoomDeserializedResponse<T>> GetDeserializedAsync<T>(
            string relativeUrl,
            IDictionary<string, string> queryParams = null)
        {
            var response = await GetAsync(relativeUrl, queryParams);

            string json = await response.Content.ReadAsStringAsync();
            return new ZoomDeserializedResponse<T>
            {
                HttpMessage = response,
                Body = JsonConvert.DeserializeObject<T>(json, GetContentSerializationSettings())
            };
        }

        private static JsonSerializerSettings GetContentSerializationSettings()
        {
            return new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new SnakeCaseNamingStrategy()
                },
            };
        }

        public Task<HttpResponseMessage> PostAsync(
            string relativeUrl,
            IDictionary<string, string> queryParams,
            object body)
        {
            return this.SendAsync(relativeUrl, queryParams, body, HttpMethod.Post);
        }

        public async Task<ZoomDeserializedResponse<T>> PostDeserializedAsync<T>(
            string relativeUrl,
            IDictionary<string, string> queryParams,
            object body)
        {
            var response = await PostAsync(relativeUrl, queryParams, body);

            string json = await response.Content.ReadAsStringAsync();
            return new ZoomDeserializedResponse<T>
            {
                HttpMessage = response,
                Body = JsonConvert.DeserializeObject<T>(json, GetContentSerializationSettings())
            };
        }

        public Task<HttpResponseMessage> PatchAsync(
            string relativeUrl,
            IDictionary<string, string> queryParams,
            object body)
        {
            return this.SendAsync(relativeUrl, queryParams, body, HttpMethod.Patch);
        }

        public Task<HttpResponseMessage> DeleteAsync(
            string relativeUrl,
            IDictionary<string, string> queryParams = null)
        {
            return this.SendAsync(relativeUrl, queryParams, null, HttpMethod.Delete);
        }
    }
}
