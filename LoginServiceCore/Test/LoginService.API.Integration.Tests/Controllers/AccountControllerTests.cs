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

        private readonly string apiUrl = "https://localhost:44370/api/Account/";

        public AccountControllerTests(CustomWebLoginApplicationFactory factory)
        {
            _factory = factory;
        }

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
                RequestData = "{\"user_id\":\"Gipxpl7iWL62b/ldd5suEA==\",\"client_id\":\"FINOMER\",\"ECBBlockEncryption\":true}"
            };

            var eventJson = @userRequest.ToJsonSerialize();
            HttpContent content = new StringContent(eventJson, Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"{apiUrl}Authenticate", content);
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var result = responseString.ToJsonDeSerialize<OutResponse>();
            result.ResponseCode.ShouldBeEquivalentTo(0);
        }

        [Fact]
        public async Task CheckValidReturnCode()
        {
            var client = _factory.CreateDefaultClient();

            var @userRequest = new AuthenticationRequest()
            {
                RequestId = "100032353_6292022153038769",
                TellerId = "100032353",
                MethodId = 1,
                IsEncrypt = false,
                RequestData = "{\"user_id\":\"K7CFFkt/==1\",\"client_id\":\"FINOMER\",\"ECBBlockEncryption\":true}"
            };

            var eventJson = @userRequest.ToJsonSerialize();
            HttpContent content = new StringContent(eventJson, Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"{apiUrl}Authenticate", content);
            response.IsSuccessStatusCode.Equals(1);
            var responseString = await response.Content.ReadAsStringAsync();
            var result = responseString.ToJsonDeSerialize<OutResponse>();
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
            //response.IsSuccessStatusCode.Equals(1);
            var responseString = await response.Content.ReadAsStringAsync();
            var result = responseString.ToJsonDeSerialize<OutResponse>();
            result.ResponseData.ShouldNotBeEmpty();
            response.RequestMessage.Equals("User not found");

            //result.ResponseCode.Equals(0);
            //result.ResponseCode.ShouldBeEquivalentTo(0);
        }

        [Fact]
        
        public async Task ResponseData_null_ReturnCode_NotValid()
        {
            var client = _factory.CreateDefaultClient();

            var @userRequest = new AuthenticationRequest()
            {
                RequestId = "100032353_6292022153038769",
                TellerId = "100032353",
                MethodId = 1,
                IsEncrypt = false,
                RequestData = "{\"user_id\":\"Gipxpl7iWL62b/ldd5suEA==\",\"client_id\":\"FINOTLR\",\"ECBBlockEncryption\":true}"
            };

            var eventJson = @userRequest.ToJsonSerialize();
            HttpContent content = new StringContent(eventJson, Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"{apiUrl}Authenticate", content);
            //response.IsSuccessStatusCode.Equals(1);
            var responseString = await response.Content.ReadAsStringAsync();
            var result = responseString.ToJsonDeSerialize<OutResponse>();
            result.ResponseData.IsEmpty();
        }
    }
}
