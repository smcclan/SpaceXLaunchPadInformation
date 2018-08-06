using Application;
using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
    public class InfrastructureAutoFacModule: Module
    {
        private string baseLaunchpadInformationUri;

        public InfrastructureAutoFacModule(string baseLaunchpadInformationUri)
        {
            this.baseLaunchpadInformationUri = baseLaunchpadInformationUri;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.Register((c, p) => new SpaceXLaunchpadAdaptor(this.baseLaunchpadInformationUri)).As<ISpaceXLaunchpadDao>();
        }
    }
}
