using Application;
using Newtonsoft.Json;

namespace Infrastructure
{
    public class ResponseLaunchpad
    {
        public long Padid { get; set; }
        public string Id { get; set; }
        public string Full_Name { get; set; }
        public string Status { get; set; }

        public LaunchpadDto ConvertToLaunchpadDto()
        {
            return new LaunchpadDto()
            {
                Id = this.Id,
                Name = this.Full_Name,
                Status = this.Status
            };
        }
    }
}
