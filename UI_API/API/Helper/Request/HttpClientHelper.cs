using UI_API.API.Modal.JsonModal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace UI_API.API.Helper.Request
{
    public class HttpClientHelper
    {
        private static HttpClient httpClient;
        private static HttpRequestMessage httpRequestMessage;
        private static RestResponse restResponse;

        private static HttpClient AddHeaderToHttpClient(Dictionary<string, string> httpHeaders)
        {
            HttpClient httpClient = new HttpClient();
            foreach (string key in httpHeaders.Keys)
                httpClient.DefaultRequestHeaders.Add(key, httpHeaders[key]);
            return httpClient;
        }

        private static HttpRequestMessage CreateHttpRequestMessage(string requestUrl, HttpMethod httpMethod)
        {
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(httpMethod, requestUrl);
            return httpRequestMessage;
        }

        private static HttpRequestMessage CreateHttpRequestMessage(string requestUrl, HttpMethod httpMethod, HttpContent httpContent)
        {
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(httpMethod, requestUrl);
            httpRequestMessage.Content = httpContent;
            return httpRequestMessage;
        }

        private static RestResponse SendRequest(string requestUrl, HttpMethod httpMethod, Dictionary<string, string> httpHeaders)
        {
            httpClient = AddHeaderToHttpClient(httpHeaders);
            httpRequestMessage = CreateHttpRequestMessage(requestUrl, httpMethod);
            Task<HttpResponseMessage> httpResponseMessage = httpClient.SendAsync(httpRequestMessage);
            try
            {
                restResponse = new RestResponse((int)httpResponseMessage.Result.StatusCode, httpResponseMessage.Result.Content.ReadAsStringAsync().Result);
            }catch(Exception err)
            {
                restResponse = new RestResponse(500, err.Message);
            }
            finally
            {
                httpRequestMessage?.Dispose();
                httpClient?.Dispose();
            }
            return restResponse;
        }

        private static RestResponse SendRequest(string requestUrl, HttpMethod httpMethod, HttpContent httpContent, Dictionary<string, string> httpHeaders)
        {
            httpClient = AddHeaderToHttpClient(httpHeaders);
            httpRequestMessage = CreateHttpRequestMessage(requestUrl, httpMethod, httpContent);
            Task<HttpResponseMessage> httpResponseMessage = httpClient.SendAsync(httpRequestMessage);
            try
            {
                restResponse = new RestResponse((int)httpResponseMessage.Result.StatusCode, httpResponseMessage.Result.Content.ReadAsStringAsync().Result);
            }
            catch (Exception err)
            {
                restResponse = new RestResponse(500, err.Message);
            }
            finally
            {
                httpRequestMessage?.Dispose();
                httpClient?.Dispose();
            }
            return restResponse;
        }

        public static RestResponse PerformGetRequest(string requestUrl, Dictionary<string, string> httpHeaders)
        {
            return SendRequest(requestUrl, HttpMethod.Get, httpHeaders);
        }

        public static RestResponse PerformPostRequest(string requestUrl,HttpContent httpContent, Dictionary<string, string> httpHeaders)
        {
            return SendRequest(requestUrl, HttpMethod.Post, httpContent, httpHeaders);
        }

        public static RestResponse PerformDeleteRequest(string requestUrl, Dictionary<string, string> httpHeaders)
        {
            return SendRequest(requestUrl, HttpMethod.Delete, httpHeaders);
        }


    }
}
