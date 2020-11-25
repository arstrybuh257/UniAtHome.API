﻿using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace UniAtHome.BLL.Services.Zoom
{
    public abstract class ZoomBaseClient
    {
        private readonly HttpClient client;

        private static readonly Uri zoomApiUrl = new Uri(@"https://zoom.us/");

        protected ZoomBaseClient(AuthenticationHeaderValue oauthHeader)
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = oauthHeader;
        }

        public Task<HttpResponseMessage> GetAsync(
            string relativeUrl,
            IDictionary<string, string> queryParams)
        {
            string requestUrl = GetAbsoluteUrlWithParams(relativeUrl, queryParams);
            return client.GetAsync(requestUrl);
        }

        public Task<HttpResponseMessage> PostAsync(
            string relativeUrl,
            IDictionary<string, string> queryParams,
            object body)
        {
            string requestUrl = GetAbsoluteUrlWithParams(relativeUrl, queryParams);

            string bodyAsJson = JsonConvert.SerializeObject(body);
            HttpContent content = new StringContent(
                content: bodyAsJson,
                encoding: Encoding.UTF8,
                mediaType: MediaTypeNames.Application.Json);

            return client.PostAsync(requestUrl, content);
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