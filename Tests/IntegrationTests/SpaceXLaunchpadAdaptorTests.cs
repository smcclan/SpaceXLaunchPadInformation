using Application;
using Infrastructure;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationTests
{
    [TestFixture]
    public class SpaceXLaunchpadAdaptorTests
    {
        SpaceXLaunchpadAdaptor adaptor;

        [SetUp]
        public void SetUp()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            adaptor = new SpaceXLaunchpadAdaptor(configuration["BaseApiUris:LaunchPadInfo"]);
        }

        [Test]
        public async Task FilterLaunchpads_ReturnsPopulatedLaunchpadDtos()
        {
            var launchpadEnumerable = await adaptor.FilterLaunchpads(new LaunchpadFilter());

            Assert.IsTrue(launchpadEnumerable.All(x => x.Id != null));
            Assert.IsTrue(launchpadEnumerable.All(x => x.Name != null));
            Assert.IsTrue(launchpadEnumerable.All(x => x.Status != null));
        }
    }
}
