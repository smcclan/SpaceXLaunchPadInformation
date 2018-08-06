using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class HealthCheckService : IHealthCheckService
    {
        ISpaceXLaunchpadDao launchpadDao;
        ILogger logger;

        public HealthCheckService(ISpaceXLaunchpadDao launchpadDao, ILogger<HealthCheckService> logger)
        {
            this.launchpadDao = launchpadDao;
            this.logger = logger;
        }

        public async Task CheckApplicationHealth()
        {
            try
            {
                await launchpadDao.FilterLaunchpads(new LaunchpadFilter());
            }
            catch(Exception ex)
            {
                logger.LogError(ex, "HealthCheck was failed when testing application dependencies");
                throw;
            }
        }
    }
}
