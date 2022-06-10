using Common.Wrappers;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Utility.Extensions;
using WebApi.Services.Settings;

namespace WebApi.Services
{
    public class WebApiRequestService : IWebApiRequestService
    {
        //private readonly AppSettings _appSettings;

        public WebApiRequestService()
        {
            //IOptions<AppSettings> appSettings
            //_appSettings = appSettings.Value;
        }

        public async Task<Response<T>> GetAsync<T, T1>(WebApiRequestSettings<T1> webApiRequestSettings, string message = "")
        {

            var sbURI = new StringBuilder(webApiRequestSettings.URL);

            if (webApiRequestSettings.QueryParameter.Count > 0)
            {
                sbURI.Append("/?");
                foreach (var query in webApiRequestSettings.QueryParameter)
                {
                    sbURI.Append(string.Format("{0}={1}&", query.Key, query.Value));
                }

                webApiRequestSettings.URL = sbURI.ToString().TrimEnd('&');
            }

            var handler = new HttpClientHandler
            {
                Credentials = CredentialCache.DefaultCredentials
            };
            var client = new HttpClient(handler)
            {
                Timeout = TimeSpan.FromMilliseconds(webApiRequestSettings.Timeout)
            };
            Uri uri = new Uri(webApiRequestSettings.URL);
            client.BaseAddress = uri;

            client.DefaultRequestHeaders.Add("X-Auth-Token", webApiRequestSettings.XAuthToken);
            client.DefaultRequestHeaders.Add("X-Source-System", "_appSettings.InstitutionId");
            client.DefaultRequestHeaders.Add("reqId", webApiRequestSettings.RequestId);
            client.DefaultRequestHeaders.Add("Connection", webApiRequestSettings.Connection);
            client.DefaultRequestHeaders.Add("Keep-Alive", "timeout=" + webApiRequestSettings.Timeout);
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(webApiRequestSettings.URL),
                Content = new StringContent(string.Empty, UnicodeEncoding.UTF8, webApiRequestSettings.ContentType)
            };



            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;

            var reply = await client.SendAsync(request).ConfigureAwait(false);
            var apiResponse = await reply.Content.ReadAsStringAsync();

            try
            {
                var output = apiResponse.ToJsonDeSerialize<T>();
                return new Response<T>(output) { StatusCode = (int)reply.StatusCode, Message = message };

            }
            catch (Exception ex)
            {
                try
                {
                    reply.EnsureSuccessStatusCode();
                    return new Response<T>() { StatusCode = (int)reply.StatusCode, Succeeded = false, Message = message, Errors = new List<string> { ex.Message } };
                }
                catch (HttpRequestException)
                {

                    var responseModel = new Response<T>() { Succeeded = false, Message = message };
                    return responseModel;
                }

            }

        }

        public async Task<Response<T>> PostAsync<T, T1>(WebApiRequestSettings<T1> webApiRequestSettings, string message = "")
        {
            string data = webApiRequestSettings.PostParameter.ToJsonSerialize();

            var stringContent = new StringContent(data, UnicodeEncoding.UTF8, webApiRequestSettings.ContentType);
            var handler = new HttpClientHandler
            {
                Credentials = CredentialCache.DefaultCredentials
            };
            var client = new HttpClient(handler)
            {
                Timeout = TimeSpan.FromMilliseconds(webApiRequestSettings.Timeout)
            };
            Uri uri = new Uri(webApiRequestSettings.URL);
            client.BaseAddress = uri;

            client.DefaultRequestHeaders.Add("X-Auth-Token", webApiRequestSettings.XAuthToken);
            client.DefaultRequestHeaders.Add("X-Source-System", "_appSettings.InstitutionId");
            client.DefaultRequestHeaders.Add("reqId", webApiRequestSettings.RequestId);
            client.DefaultRequestHeaders.Add("X-Correlation-Id", webApiRequestSettings.RequestId);
            client.DefaultRequestHeaders.Add("Connection", webApiRequestSettings.Connection);
            client.DefaultRequestHeaders.Add("Keep-Alive", "timeout=" + webApiRequestSettings.Timeout);
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;

            var reply = await client.PostAsync(webApiRequestSettings.URL, stringContent);

            string apiResponse = await reply.Content.ReadAsStringAsync();

            try
            {
                var output = apiResponse.ToJsonDeSerialize<T>();
                return new Response<T>(output) { StatusCode = (int)reply.StatusCode, Message = message };

            }
            catch (Exception ex)
            {
                try
                {
                    reply.EnsureSuccessStatusCode();
                    return new Response<T>() { StatusCode = (int)reply.StatusCode, Succeeded = false, Message = message, Errors = new List<string> { ex.Message } };
                }
                catch (HttpRequestException)
                {

                    var responseModel = new Response<T>() { Succeeded = false, Message = message };

                    //switch (httpexception.StatusCode)
                    //{
                    //    case HttpStatusCode.Unauthorized:
                    //        responseModel.StatusCode = (int)HttpStatusCode.Unauthorized;
                    //        responseModel.Errors = new List<string> { "You are not Authorized" };
                    //        break;
                    //    default:
                    //        responseModel.StatusCode = (int)httpexception.StatusCode;
                    //        responseModel.Errors = new List<string> { responseModel.Message };
                    //        break;
                    //}
                    return responseModel;
                }
            }
        }
    }
}
