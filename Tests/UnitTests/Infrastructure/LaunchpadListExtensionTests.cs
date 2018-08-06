using Application;
using AutoFixture;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using Infrastructure;

namespace UnitTests.Infrastructure
{
    [TestFixture]
    public class LaunchpadListExtensionTests
    {
        Fixture fixture;

        List<LaunchpadDto> dtoList;

        [SetUp]
        public void SetUp()
        {
            this.fixture = new Fixture();

            this.dtoList = fixture.CreateMany<LaunchpadDto>(5).ToList();
        }

        [Test]
        public void ApplyFilter_AppliesFilter_ToLaunchpadList()
        {
            var filter = new LaunchpadFilter()
            {
                LaunchpadIds = new List<string>() { this.dtoList[0].Id }
            };

            Assert.AreEqual(1, dtoList.ApplyFilter(filter).Count());
        }

        [Test]
        public void ApplyFilter_AppliesCombinationFilter_ToLaunchpadList()
        {
            var filter = new LaunchpadFilter()
            {
                LaunchpadIds = new List<string>() { this.dtoList[0].Id },
                LaunchpadNames = new List<string>() { this.dtoList[1].Name }
            };

            Assert.AreEqual(0, dtoList.ApplyFilter(filter).Count());
        }
    }
}
