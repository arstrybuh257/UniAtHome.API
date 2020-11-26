using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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

        public virtual async Task<HttpResponseMessage> GetAsync(
            string relativeUrl,
            IDictionary<string, string> queryParams)
        {
            string requestUrl = GetAbsoluteUrlWithParams(relativeUrl, queryParams);

            client.DefaultRequestHeaders.Authorization = await GetAuthHeaderAsync();

            return await client.GetAsync(requestUrl);
        }

        public async Task<ZoomDeserializedResponse<T>> GetDeserializedAsync<T>(
            string relativeUrl,
            IDictionary<string, string> queryParams)
        {
            using var response = await GetAsync(relativeUrl, queryParams);

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

        public virtual async Task<HttpResponseMessage> PostAsync(
            string relativeUrl,
            IDictionary<string, string> queryParams,
            object body)
        {
            string requestUrl = GetAbsoluteUrlWithParams(relativeUrl, queryParams);

            string bodyAsJson = JsonConvert.SerializeObject(body, GetContentSerializationSettings());
            HttpContent content = new StringContent(
                content: bodyAsJson,
                encoding: Encoding.UTF8,
                mediaType: MediaTypeNames.Application.Json);

            client.DefaultRequestHeaders.Authorization = await GetAuthHeaderAsync();

            return await client.PostAsync(requestUrl, content);
        }

        public async Task<ZoomDeserializedResponse<T>> PostDeserializedAsync<T>(
            string relativeUrl,
            IDictionary<string, string> queryParams,
            object body)
        {
            using var response = await PostAsync(relativeUrl, queryParams, body);

            string json = await response.Content.ReadAsStringAsync();
            return new ZoomDeserializedResponse<T>
            {
                HttpMessage = response,
                Body = JsonConvert.DeserializeObject<T>(json, GetContentSerializationSettings())
            };
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
    }
}
