using Application;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class SpaceXLaunchpadAdaptor : ISpaceXLaunchpadDao
    {
        private string launchPadBaseUri;

        public SpaceXLaunchpadAdaptor(string baseUri)
        {
            this.launchPadBaseUri = baseUri;
        }

        public async Task<IEnumerable<LaunchpadDto>> FilterLaunchpads(LaunchpadFilter filter)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(this.launchPadBaseUri);
                var responseBody = await response.Content.ReadAsStringAsync();

                var launchPadList = JsonConvert.DeserializeObject<List<ResponseLaunchpad>>(responseBody);

                var launchPadDtoList = launchPadList.Select(x => x.ConvertToLaunchpadDto());

                return launchPadDtoList.ApplyFilter(filter);
            }
        }
    }
}
