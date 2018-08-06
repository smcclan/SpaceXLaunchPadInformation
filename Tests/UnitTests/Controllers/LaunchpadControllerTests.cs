using Application;
using AutoFixture;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using Service.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Controllers
{
    [TestFixture]
    public class LaunchpadControllerTests
    {
        private LaunchpadController controller;
        private Mock<ILaunchpadService> launchpadServiceMock;
        private Fixture fixture;

        [SetUp]
        public void SetUp() {
            fixture = new Fixture();

            launchpadServiceMock = new Mock<ILaunchpadService>();
            var logger = new Mock<ILogger<LaunchpadController>>();

            this.controller = new LaunchpadController(launchpadServiceMock.Object, logger.Object);
        }

        [Test]
        public async Task FilterLaunchpads_ReturnsBadRequest_WhenFilterIsMalFormed()
        {
            var malformedFilter = fixture.Build<LaunchpadFilter>().With(x => x.PageNumber, -1).OmitAutoProperties().Create();

            var response = await this.controller.FilterLaunchpads(malformedFilter);

            Assert.IsInstanceOf<BadRequestResult>(response);
        }

        [Test]
        public async Task FilterLaunchpads_ReturnsOkRequest_WithValidFilter()
        {
            var filter = new LaunchpadFilter();

            var response = await this.controller.FilterLaunchpads(filter);

            Assert.IsInstanceOf<OkObjectResult>(response);
        }

        [Test]
        public void FilterLaunchpads_ReturnInternalServerError_WhenExceptionIsThrown()
        {
            var filter = new LaunchpadFilter();

            launchpadServiceMock.Setup(x => x.FilterLaunchPads(It.IsAny<LaunchpadFilter>())).ThrowsAsync(new Exception());

            Assert.ThrowsAsync<Exception>(async () => await this.controller.FilterLaunchpads(filter));
        }
    }
}

