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

        public WebApiRequestService()
        {

        }

        public async Task<Response<TResponse>> GetAsync<TResponse, TRequest>(WebApiRequestSettings<TRequest> webApiRequestSettings, string message = "") where TRequest : new()
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
                var output = apiResponse.ToJsonDeSerialize<TResponse>();
                return new Response<TResponse>(output) { StatusCode = (int)reply.StatusCode, Message = message };

            }
            catch (Exception ex)
            {
                try
                {
                    reply.EnsureSuccessStatusCode();
                    return new Response<TResponse>() { StatusCode = (int)reply.StatusCode, Succeeded = false, Message = message, Errors = new List<string> { ex.Message } };
                }
                catch (HttpRequestException)
                {

                    var responseModel = new Response<TResponse>() { Succeeded = false, Message = message };
                    return responseModel;
                }

            }

        }

        public async Task<Response<TResponse>> PostAsync<TResponse, TRequest>(WebApiRequestSettings<TRequest> webApiRequestSettings, string message = "") where TRequest : new()
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
            //client.DefaultRequestHeaders.Add("X-Source-System", "_appSettings.InstitutionId");

            if (!string.IsNullOrEmpty(webApiRequestSettings.RequesterId))
            {
                client.DefaultRequestHeaders.Add("RequestorId", webApiRequestSettings.RequesterId);
            }

            client.DefaultRequestHeaders.Add("X-Correlation-Id", webApiRequestSettings.RequestId);

            if (!string.IsNullOrEmpty(webApiRequestSettings.TokenId))
            {
                client.DefaultRequestHeaders.Add("TokenId", webApiRequestSettings.TokenId);
            }

            client.DefaultRequestHeaders.Add("Connection", webApiRequestSettings.Connection);
            client.DefaultRequestHeaders.Add("Keep-Alive", "timeout=" + webApiRequestSettings.Timeout);



            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;

            var reply = await client.PostAsync(webApiRequestSettings.URL, stringContent);


            if (reply.StatusCode == HttpStatusCode.OK)
            {
                string apiResponse = await reply.Content.ReadAsStringAsync();
                apiResponse = "{\"id_token\":\"PWD-fcdc44ce-4b67-4a06-b9de-066ead82c79d\",\"date2\":\"Jul5,20226:59:16PM\",\"token_type\":\"Bearer\",\"userDetails\":{\"identifier\":\"100032353\",\"name\":\"DineshJondhale\",\"userClass\":{\"code\":\"MER3\",\"description\":\"FinoMerchant3\",\"maxDaysBackdatedAllowed\":2,\"maxDaysFutureDatedAllowed\":1},\"branchAssociated\":{\"code\":\"1021\",\"description\":\"Khurai\",\"ifsc\":\"FINO0000001\",\"micr\":\"700750064\",\"grid\":0,\"defaultCostCenter\":1021,\"branchType\":{\"type\":\"4\",\"description\":\"RURAL\",\"subType\":\"43\",\"subtypedescription\":\"REL_Y_BC_RRL\"},\"address\":{\"addressLine1\":\"GrFloor,ShopNo.8/9/10,ParshaChowk\",\"addressLine2\":\"NrRBLBranch,NehruWard,StationRoad\",\"addressLine3\":\"Khurai,DistrictSagar,MP\",\"city\":\"Sagar\",\"state\":\"MP\",\"stateDescription\":\"MadhyaPradesh\",\"pinCode\":\"470117\",\"country\":\"IN\"},\"cashOpen\":true,\"cts\":false,\"gridBranch\":false},\"allowedToChangePostingDate\":false,\"currencyEnvironment\":0,\"primaryCashLimit\":1.229489968E7,\"passwordExpired\":true,\"agencyDetails\":{},\"fPIndex\":0,\"mobileNumber\":\"8055988351\",\"status\":\"1\",\"revoked\":\"false\",\"lastLoginDate\":[2022,7,5],\"lastLoginTime\":[19,22,17],\"passwordExpirationDate\":[2021,5,18],\"merchantAccount\":\"20000215496\",\"supervisorId\":\"2\"},\"succeeded_schemes\":[\"PWD\"],\"access_token\":\"eyJhbGciOiJIUzI1NiJ9.eyJyb2xlcyI6WyJNRVIzIl0sImp0aSI6IjM0NDg5YzhiLTRjZDUtNGY5ZC04NWE5LWNkMTU1NTA2ZmVjYiIsImlhdCI6IjE2NTcwMjkxMzciLCJpc3MiOiJhdXRobWFuIiwidXNlcl9pZCI6IjEwMDAzMjM1MyIsImlwX2FkZHJlc3MiOm51bGwsImdlb19sb2NhdGlvbiI6bnVsbCwiY2xpZW50X2lkIjoiRklOT01FUiIsIm1taWQiOm51bGwsIm1hcHBlZF91c2VyX2lkIjoiMTAwMDMyMzUzIiwiZnVsbF9uYW1lIjoiRGluZXNoIEpvbmRoYWxlIiwiYnJhbmNoX2NvZGUiOiIxMDIxIiwiZmlyc3RMb2dpbktpbGxlZCI6bnVsbCwic3ViVWNscyI6MH0.3S7l0AIdf3Xdv4d1Q1LYfNiJc4X9Wdkb0hwkKkGdkVw\",\"returnCode\":\"0\",\"firstLoginKilled\":true,\"refresh_expires_in\":0,\"balancesList\":[{\"accountNo\":\"20000215496\",\"ledgerBalance\":6147449.84,\"availableBalance\":6147449.84,\"currency\":\"INR\"}],\"responseMessage\":\"\",\"expires_in\":1657030937806,\"errors\":[],\"force_change_password\":false,\"tellerProofList\":null}";

                try
                {
                    var output = apiResponse.ToJsonDeSerialize<TResponse>();
                    return new Response<TResponse>(output) { StatusCode = (int)reply.StatusCode, Message = message };

                }
                catch (Exception ex)
                {
                    return new Response<TResponse>() { StatusCode = (int)reply.StatusCode, Message = message, Succeeded = false, ErrorMessage = !(string.IsNullOrEmpty(apiResponse)) ? apiResponse : string.Empty, Errors = new List<string>() };
                }
            }
            else
            {
                return new Response<TResponse>() { StatusCode = (int)reply.StatusCode, ErrorMessage = reply.ReasonPhrase, Message = reply.ReasonPhrase };
            }
        }
    }
}
