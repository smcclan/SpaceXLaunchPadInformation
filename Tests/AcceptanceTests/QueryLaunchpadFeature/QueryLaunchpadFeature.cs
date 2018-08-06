using LightBDD.Framework.Scenarios.Basic;
using LightBDD.NUnit3;
using System.Threading.Tasks;

namespace AcceptanceTests.QueryLaunchpadFeature
{
    public partial class QueryLaunchpadFeature
    {
        [Scenario]
        public async Task HttpGetWithNoFilterGetsAllLaunchpadInformation()
        {
            await Runner.RunScenarioActionsAsync(
                Given_An_Http_Get_Request,
                When_The_List_Of_Launchpads_Is_Returned,
                Then_All_Launchpads_Are_Returned);
        }

        [Scenario]
        public async Task FilterOnIds()
        {
            await Runner.RunScenarioActionsAsync(
                Given_A_Launchpad_Filter_Request_On_Two_Ids,
                When_The_List_Of_Launchpads_Is_Returned,
                Then_The_Results_Are_Filtered);
        }

        [Scenario]
        public async Task FilterOnNames()
        {
            await Runner.RunScenarioActionsAsync(
                Given_A_Launchpad_Filter_Request_On_Two_Names,
                When_The_List_Of_Launchpads_Is_Returned,
                Then_The_Results_Are_Filtered);
        }

        [Scenario]
        public async Task FilterOnStatus()
        {
            await Runner.RunScenarioActionsAsync(
                Given_A_Launchpad_Filter_Request_On_Status,
                When_The_List_Of_Launchpads_Is_Returned,
                Then_The_Results_Are_Filtered);
        }

        [Scenario]
        public async Task FilterOnPage()
        {
            await Runner.RunScenarioActionsAsync(
                Given_A_Launchpad_Filter_Request_On_PageSize,
                When_The_List_Of_Launchpads_Is_Returned,
                Then_The_Results_Are_Filtered);
        }
    }
}
