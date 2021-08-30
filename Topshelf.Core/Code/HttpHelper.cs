using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Topshelf.Core
{
    public class HttpHelper
    {
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
            HttpContent httpContent = new StringContent(postData);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            httpContent.Headers.ContentType.CharSet = "utf-8";
            HttpClient httpClient = new HttpClient();
            Task<HttpResponseMessage> task = httpClient.PostAsync("http://" + url, httpContent); /*这里请求时用到同步*/
            var response = task.Result;
            if (response.IsSuccessStatusCode)
            {
                var read = response.Content.ReadAsStringAsync();
                result = read.Result;
            }
            return result;
        }
    }
}
