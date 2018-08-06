using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using SpaceXLaunchPadInformation;

namespace AcceptanceTests
{
    public class TestServerFactory
    {
        public static TestServer Create()
        {
            var builder = new WebHostBuilder()
                .UseConfiguration(new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json")
                    .Build()
                )
                .UseStartup<Startup>(); 

            return new TestServer(builder);
        }
    }
}
