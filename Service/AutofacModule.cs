using Application;
using Autofac;
using Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;

namespace Service
{
    public class AutofacModule: Module
    {
        private IConfiguration config;

        private const string launchpadUriConfigPath = "BaseApiUris:LaunchPadInfo";

        public AutofacModule(IConfiguration configuration){
            this.config = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            var launchPadInfoUri = config[launchpadUriConfigPath];

            if(launchPadInfoUri == null)
            {
                throw new Exception($"The path to the launchpad base uri in the application.json was not found using the path {launchpadUriConfigPath}");
            }

            builder.RegisterModule(new ApplicationAutoFacModule());
            builder.RegisterModule(new InfrastructureAutoFacModule(launchPadInfoUri));
        }
    }
}
