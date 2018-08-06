using Application;
using LightBDD.NUnit3;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AcceptanceTests.QueryLaunchpadFeature
{
    public partial class QueryLaunchpadFeature : FeatureFixture
    {
        TestServer testServer;
        HttpClient testServerClient;

        List<LaunchpadDto> launchpads;

        LaunchpadFilter filter;
        IEnumerable<LaunchpadDto> responseLaunchpadList;

        [SetUp]
        public async Task SetUp()
        {
            this.testServer = TestServerFactory.Create();
            this.testServerClient = this.testServer.CreateClient();

            var response = await testServer.CreateClient().GetAsync("api/launchpads");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            launchpads = JsonConvert.DeserializeObject<List<LaunchpadDto>>(responseString);
        }

        private void Given_An_Http_Get_Request()
        {
            filter = null;
        }

        private void Given_A_Launchpad_Filter_Request_On_Two_Ids()
        {
            var launchpadId1 = launchpads[0].Id;
            var launchpadId2 = launchpads[1].Id;

            filter = new LaunchpadFilter()
            {
                LaunchpadIds = new List<string>() { launchpadId1, launchpadId2 }
            };
        }

        private void Given_A_Launchpad_Filter_Request_On_Two_Names()
        {
            var launchpadName1 = launchpads[0].Name;
            var launchpadName2 = launchpads[1].Name;

            filter = new LaunchpadFilter()
            {
                LaunchpadNames = new List<string>() { launchpadName1, launchpadName2 }
            };
        }

        private void Given_A_Launchpad_Filter_Request_On_Status()
        {
            var launchpadStatus = launchpads[3].Status;

            filter = new LaunchpadFilter()
            {
                LaunchpadStatus = launchpadStatus
            };
        }

        private void Given_A_Launchpad_Filter_Request_On_PageSize()
        {
            filter = new LaunchpadFilter()
            {
                PageSize = 1,
                PageNumber = 1
            };
        }

        private async void When_The_List_Of_Launchpads_Is_Returned()
        {
            string query = "";

            if (filter != null)
            {
                query = "?"+ filter.ToQueryString();
            }

            var response = await testServer.CreateClient().GetAsync("api/launchpads" + query);
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            responseLaunchpadList = JsonConvert.DeserializeObject<List<LaunchpadDto>>(responseString);
        }

        private void Then_All_Launchpads_Are_Returned()
        {
            Assert.IsTrue(launchpads.TrueForAll(x => responseLaunchpadList.Contains(x)));
        }

        private void Then_The_Results_Are_Filtered()
        {
            Assert.IsTrue(filter.HasBeenAppliedTo(responseLaunchpadList));
        }
    }
}
