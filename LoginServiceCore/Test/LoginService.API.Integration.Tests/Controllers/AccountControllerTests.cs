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
        public async Task Validate_Authentication_User_ReturnsSuccessResult()
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
            var result = responseString.ToJsonDeSerialize<OutResponse>();
            result.ResponseCode.ShouldBeEquivalentTo(0);
        }
        public async Task Validate_Authentication_UserWrong_ReturnsFailResult()
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
            var response = await client.PutAsync($"{apiUrl}Authenticate", content);
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var result = responseString.ToJsonDeSerialize<OutResponse>();
            result.ResponseCode.ShouldBeEquivalentTo(0);
        }


    }
}
