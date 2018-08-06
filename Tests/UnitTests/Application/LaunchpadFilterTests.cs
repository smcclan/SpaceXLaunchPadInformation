using Application;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests.Application
{
    [TestFixture]
    public class LaunchpadFilterTests
    {
        [Test]
        public void LaunchpadFilter_InitializedLists_WhenConstructed()
        {
            var filter = new LaunchpadFilter();

            Assert.IsNotNull(filter.LaunchpadIds);
            Assert.IsNotNull(filter.LaunchpadNames);
        }

        [Test]
        public void IsValid_ReturnsTrue_WhenFilterIsEmpty()
        {
            var filter = new LaunchpadFilter();

            Assert.IsTrue(filter.IsValid());
        }

        [Test]
        public void IsValid_RertunsFalse_WhenPageNumberIsLessThan1()
        {
            var filter = new LaunchpadFilter()
            {
                PageNumber = 0,
                PageSize = 1
            };

            Assert.IsFalse(filter.IsValid());
        }

        [Test]
        public void IsValid_RertunsFalse_WhenPageSizeIsLessThan1()
        {
            var filter = new LaunchpadFilter()
            {
                PageNumber = 1,
                PageSize = 0
            };

            Assert.IsFalse(filter.IsValid());
        }

        [Test]
        public void IsValie_ReturnsFalse_WhenAllIdsAreNull()
        {
            var filter = new LaunchpadFilter()
            {
                LaunchpadIds = new List<string>() { null }
            };

            Assert.IsFalse(filter.IsValid());
        }

        [Test]
        public void IsValie_ReturnsFalse_WhenAllNamesAreNull()
        {
            var filter = new LaunchpadFilter()
            {
                LaunchpadNames = new List<string>() { null }
            };

            Assert.IsFalse(filter.IsValid());
        }
    }
}
