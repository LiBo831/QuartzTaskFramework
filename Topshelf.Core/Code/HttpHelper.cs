using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Topshelf.Core
{
    public class HttpHelper
    {
        private static HttpClient httpClient = new HttpClient();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="postData">请求参数</param>
        /// <param name="access_token">授权Token</param>
        /// <returns></returns>
        public static string PostResponseAsync(string url, string postData)
        {
            string result = null;
            string baseUri = $"http://{url}";
            HttpContent httpContent = new StringContent(postData);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            httpContent.Headers.ContentType.CharSet = "utf-8";
            ServicePointManager.FindServicePoint(new Uri(baseUri)).ConnectionLeaseTimeout = 30 * 1000;
            var response = httpClient.PostAsync("http://" + url, httpContent).Result;
            if (response.IsSuccessStatusCode)
            {
                var read = response.Content.ReadAsStringAsync();
                result = read.Result;
            }
            return result;
        }
    }
}
