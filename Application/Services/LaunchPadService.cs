using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class LaunchpadService : ILaunchpadService
    {
        ISpaceXLaunchpadDao launchpadDao;
        ILogger logger;

        public LaunchpadService(ISpaceXLaunchpadDao launchpadDao, ILogger<LaunchpadService> logger)
        {
            this.launchpadDao = launchpadDao;
            this.logger = logger;
        }

        public Task<IEnumerable<LaunchpadDto>> FilterLaunchPads(LaunchpadFilter filter)
        {
            return launchpadDao.FilterLaunchpads(filter);
        }
    }
}
