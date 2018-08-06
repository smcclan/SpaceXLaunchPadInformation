using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public class ApplicationAutoFacModule: Module
    {
        public bool ObeySpeedLimit { get; set; }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<LaunchpadService>().As<ILaunchpadService>();
            builder.RegisterType<HealthCheckService>().As<IHealthCheckService>();
        }
    }
}
