using Microsoft.AspNetCore.Mvc.Testing;
using SampleWebAPI;

namespace Sample.API.IntegrationTests.Base
{

    public class CustomWebApplicationFactory : WebApplicationFactory<Startup>
    {
    }
}
