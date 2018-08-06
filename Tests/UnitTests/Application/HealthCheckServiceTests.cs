using Application;
using AutoFixture;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Application
{
    [TestFixture]
    public class HealthCheckServiceTests
    {
        Mock<ISpaceXLaunchpadDao> launchpadDaoMock;
        HealthCheckService service;

        [SetUp]
        public void SetUp()
        {
            var logger = new Mock<ILogger<HealthCheckService>>();

            var fixture = new Fixture();

            this.launchpadDaoMock = new Mock<ISpaceXLaunchpadDao>();
            this.launchpadDaoMock.Setup(x => x.FilterLaunchpads(It.IsAny<LaunchpadFilter>()))
                .ReturnsAsync(fixture.CreateMany<LaunchpadDto>(2)).Verifiable();

            this.service = new HealthCheckService(this.launchpadDaoMock.Object, logger.Object);
        }

        [Test]
        public async Task CheckApplicationHealth_CallsFilterLaunchpads()
        {
            await service.CheckApplicationHealth();

            this.launchpadDaoMock.VerifyAll();
        }
    }
}
