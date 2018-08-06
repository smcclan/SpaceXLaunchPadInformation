using Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Service.Controllers
{
    [Route("api/launchpads")]
    public class LaunchpadController: Controller
    {
        ILaunchpadService launchpadService;
        ILogger logger;

        public LaunchpadController(ILaunchpadService launchpadService, ILogger<LaunchpadController> logger)
        {
            this.launchpadService = launchpadService;
            this.logger = logger;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> FilterLaunchpads(LaunchpadFilter filter)
        {
            filter = filter ?? new LaunchpadFilter();
            try
            {
                if(!filter.IsValid())
                {
                    return BadRequest();
                }

                var launchPads = await this.launchpadService.FilterLaunchPads(filter);
                return Ok(launchPads);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Unhandled error thrown while retrieving launchpad information with filter {filter}");
                throw;
            }
        }
    }
}
