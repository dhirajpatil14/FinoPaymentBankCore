using Common.Application.Model;
using LoginService.API.Integration.Tests.Base;
using LoginService.Application.Models;
using Shouldly;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Utility.Extensions;
using Xunit;

namespace LoginService.API.Integration.Tests.Controllers
{
    public class AccountControllerTests : IClassFixture<CustomWebLoginApplicationFactory>
    {

        private readonly CustomWebLoginApplicationFactory _factory;

        private readonly string apiUrl = "https://localhost:44372/api/Account/";

        public AccountControllerTests(CustomWebLoginApplicationFactory factory)
        {
            _factory = factory;
        }

        #region Method 1

        [Fact]
        public async Task Validate_User_ReturnsSuccessResult()
        {
            var client = _factory.CreateDefaultClient();

            var @userRequest = new AuthenticationRequest()
            {
                RequestId = "100032353_6292022153038769",
                TellerId = "100032353",
                MethodId = 1,
                IsEncrypt = false,
                RequestData = "{\"user_id\":\"K7CFFkt/XuWxCJZLlXpFQg==\",\"client_id\":\"FINOMER\",\"ECBBlockEncryption\":true}"
            };

            var eventJson = @userRequest.ToJsonSerialize();
            HttpContent content = new StringContent(eventJson, Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"{apiUrl}Authenticate", content);
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            responseString.ShouldNotBeNullOrEmpty();
            var result = responseString.ToJsonDeSerialize<OutResponse>();
            result.ResponseData.ShouldNotBeNullOrEmpty();
            result.ResponseCode.ShouldBeEquivalentTo(0);
        }

        [Fact]
        public async Task Incorrect_UserId_ReturnCode_NotValid()
        {
            var client = _factory.CreateDefaultClient();

            var @userRequest = new AuthenticationRequest()
            {
                RequestId = "100032353_6292022153038769",
                TellerId = "100032353",
                MethodId = 1,
                IsEncrypt = false,
                RequestData = "{\"user_id\":\"LmTzLdp6IF5kHqiShhkkAw==\",\"client_id\":\"FINOMER\",\"ECBBlockEncryption\":true}"

            };

            var eventJson = @userRequest.ToJsonSerialize();
            HttpContent content = new StringContent(eventJson, Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"{apiUrl}Authenticate", content);
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            responseString.ShouldNotBeNullOrEmpty();

            var result = responseString.ToJsonDeSerialize<OutResponse>();
            result.ResponseCode.ShouldBeEquivalentTo(1);
            result.ResponseData.ShouldNotBeNullOrEmpty();
            result.ResponseMessage.ShouldBeEquivalentTo("User not found");
        }

        #endregion

        #region Method 2
        [Fact]
        public async Task Validate_Web_User_Password_ReturnsSuccessResult()
        {
            var client = _factory.CreateDefaultClient();

            var @userRequest = new AuthenticationRequest()
            {
                RequestId = "100032353_711202216413532",
                TellerId = "100032353",
                MethodId = 2,
                IsEncrypt = false,
                RequestData = "{\"user_id\":\"K7CFFkt/XuWxCJZLlXpFQg==\",\"password\":\"fJx6WgNHnWnYV/aRNnaBmA==\",\"client_id\":\"FINOMER\",\"systemInfo\":{\"Channel\":\"2\",\"ISP\":\"Fino\",\"browser\":\"chrome 103.0.0.0\",\"Lattitude\":38.9847719,\"Longitude\":-77.5619419,\"version\":\"103.0.0.0\",\"PostalCode\":\"\",\"MAC_DeviceID\":\"12345\",\"CellID\":\"54321\",\"DeviceModel\":\"unknown\",\"DeviceOS\":\"windows\",\"MCC\":\"Test_MCC\",\"MNC\":\"Test_MNC\",\"LanguageSupported\":\"en-US\"},\"geoLocation\":{\"Lattitude\":38.9847719,\"Longitude\":-77.5619419},\"deviceId\":null,\"xauthToken\":null,\"biometric_fp\":{},\"otp\":{},\"Aadhaar\":{},\"ECBBlockEncryption\":true,\"EncType\":\"NEW\"}"
            };

            var eventJson = @userRequest.ToJsonSerialize();
            HttpContent content = new StringContent(eventJson, Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"{apiUrl}Authenticate", content);
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            responseString.ShouldNotBeNullOrEmpty();
            var result = responseString.ToJsonDeSerialize<OutResponse>();
            result.ResponseData.ShouldNotBeNullOrEmpty();
            result.ResponseCode.ShouldBeEquivalentTo(0);
        }

        public async Task Validate_Web_User_Password_Wrong_ReturnUnsuccesssfullResult()
        {
            var client = _factory.CreateDefaultClient();

            var @userRequest = new AuthenticationRequest()
            {
                RequestId = "100032353_711202216413532",
                TellerId = "100032353",
                MethodId = 2,
                IsEncrypt = false,
                RequestData = "{\"user_id\":\"K7CFFkt/XuWxCJZLlXpFQg==\",\"password\":\"fJx6WgNHnWnYV/aRNnaBmA==\",\"client_id\":\"FINOMER\",\"systemInfo\":{\"Channel\":\"2\",\"ISP\":\"Fino\",\"browser\":\"chrome 103.0.0.0\",\"Lattitude\":38.9847719,\"Longitude\":-77.5619419,\"version\":\"103.0.0.0\",\"PostalCode\":\"\",\"MAC_DeviceID\":\"12345\",\"CellID\":\"54321\",\"DeviceModel\":\"unknown\",\"DeviceOS\":\"windows\",\"MCC\":\"Test_MCC\",\"MNC\":\"Test_MNC\",\"LanguageSupported\":\"en-US\"},\"geoLocation\":{\"Lattitude\":38.9847719,\"Longitude\":-77.5619419},\"deviceId\":null,\"xauthToken\":null,\"biometric_fp\":{},\"otp\":{},\"Aadhaar\":{},\"ECBBlockEncryption\":true,\"EncType\":\"NEW\"}"
            };

            var eventJson = @userRequest.ToJsonSerialize();
            HttpContent content = new StringContent(eventJson, Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"{apiUrl}Authenticate", content);
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            responseString.ShouldNotBeNullOrEmpty();
            var result = responseString.ToJsonDeSerialize<OutResponse>();
            result.ResponseData.ShouldNotBeNullOrEmpty();
            result.ResponseCode.ShouldBeEquivalentTo(0);
        }


        public async Task Validate_Mobile_User_Password_ReturnsSuccessResult()
        {
            var client = _factory.CreateDefaultClient();

            var @userRequest = new AuthenticationRequest()
            {
                RequestId = "100032353_711202216413532",
                TellerId = "100032353",
                MethodId = 2,
                IsEncrypt = false,
                RequestData = "{\"user_id\":\"K7CFFkt/XuWxCJZLlXpFQg==\",\"password\":\"fJx6WgNHnWnYV/aRNnaBmA==\",\"client_id\":\"FINOMER\",\"systemInfo\":{\"Channel\":\"2\",\"ISP\":\"Fino\",\"browser\":\"chrome 103.0.0.0\",\"Lattitude\":38.9847719,\"Longitude\":-77.5619419,\"version\":\"103.0.0.0\",\"PostalCode\":\"\",\"MAC_DeviceID\":\"12345\",\"CellID\":\"54321\",\"DeviceModel\":\"unknown\",\"DeviceOS\":\"windows\",\"MCC\":\"Test_MCC\",\"MNC\":\"Test_MNC\",\"LanguageSupported\":\"en-US\"},\"geoLocation\":{\"Lattitude\":38.9847719,\"Longitude\":-77.5619419},\"deviceId\":null,\"xauthToken\":null,\"biometric_fp\":{},\"otp\":{},\"Aadhaar\":{},\"ECBBlockEncryption\":true,\"EncType\":\"NEW\"}"
            };

            var eventJson = @userRequest.ToJsonSerialize();
            HttpContent content = new StringContent(eventJson, Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"{apiUrl}Authenticate", content);
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            responseString.ShouldNotBeNullOrEmpty();
            var result = responseString.ToJsonDeSerialize<OutResponse>();
            result.ResponseData.ShouldNotBeNullOrEmpty();
            result.ResponseCode.ShouldBeEquivalentTo(0);
        }

        public async Task Validate_Mobile_User_Password_Wrong_ReturnUnsuccesssfullResult()
        {
            var client = _factory.CreateDefaultClient();

            var @userRequest = new AuthenticationRequest()
            {
                RequestId = "100032353_711202216413532",
                TellerId = "100032353",
                MethodId = 2,
                IsEncrypt = false,
                RequestData = "{\"user_id\":\"K7CFFkt/XuWxCJZLlXpFQg==\",\"password\":\"fJx6WgNHnWnYV/aRNnaBmA==\",\"client_id\":\"FINOMER\",\"systemInfo\":{\"Channel\":\"2\",\"ISP\":\"Fino\",\"browser\":\"chrome 103.0.0.0\",\"Lattitude\":38.9847719,\"Longitude\":-77.5619419,\"version\":\"103.0.0.0\",\"PostalCode\":\"\",\"MAC_DeviceID\":\"12345\",\"CellID\":\"54321\",\"DeviceModel\":\"unknown\",\"DeviceOS\":\"windows\",\"MCC\":\"Test_MCC\",\"MNC\":\"Test_MNC\",\"LanguageSupported\":\"en-US\"},\"geoLocation\":{\"Lattitude\":38.9847719,\"Longitude\":-77.5619419},\"deviceId\":null,\"xauthToken\":null,\"biometric_fp\":{},\"otp\":{},\"Aadhaar\":{},\"ECBBlockEncryption\":true,\"EncType\":\"NEW\"}"
            };

            var eventJson = @userRequest.ToJsonSerialize();
            HttpContent content = new StringContent(eventJson, Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"{apiUrl}Authenticate", content);
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            responseString.ShouldNotBeNullOrEmpty();
            var result = responseString.ToJsonDeSerialize<OutResponse>();
            result.ResponseData.ShouldNotBeNullOrEmpty();
            result.ResponseCode.ShouldBeEquivalentTo(0);
        }

        #endregion
    }
}
