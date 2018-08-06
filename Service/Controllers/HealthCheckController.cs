using Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Service.Controllers
{
    [Route("api/health-check")]
    public class HealthCheckController: Controller
    {
        IHealthCheckService healthCheckService;
        private ILogger logger;

        public HealthCheckController(IHealthCheckService healthCheckService, ILogger<HealthCheckController> logger)
        {
            this.healthCheckService = healthCheckService;
            this.logger = logger;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> HealthCheck()
        {
            try
            {
                await healthCheckService.CheckApplicationHealth();
                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"An exception was thrown during the health check");
                throw;
            }
        }
    }
}
