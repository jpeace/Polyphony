using System.Web.Routing;
using AutoMapper;
using FubuCore;
using FubuMVC.StructureMap;
using Microsoft.Practices.ServiceLocation;
using Polyphony.Core.Configuration;
using Polyphony.Core.Infrastructure;
using Polyphony.Web.Infrastructure.Mappers;
using StructureMap;
using StructureMapServiceLocator = Polyphony.Core.Infrastructure.StructureMapServiceLocator;

namespace Polyphony.Web.Configuration
{
    public class FubuStructureMapBootstrapper : IBootstrapper
    {
        private readonly RouteCollection _routes;

        private FubuStructureMapBootstrapper(RouteCollection routes)
        {
            _routes = routes;
        }

        public void BootstrapStructureMap()
        {
            UrlContext.Reset();

            ObjectFactory.Initialize(x => x.IncludeRegistry(new CoreRegistry()));

            ServiceLocator.SetLocatorProvider(() => new StructureMapServiceLocator(ObjectFactory.Container));
            //NOTE: AutoMapper extensions use the CSL so this must come after the SetLocatorProvider call
            Mapper.Initialize(x => x.AddAllFromAssemblyContainingType<UserToUserDetailsMapper>());

            BootstrapFubu(ObjectFactory.Container, _routes);
        }

        private static void BootstrapFubu(IContainer container, RouteCollection routes)
        {
            var bootstrapper = new StructureMapBootstrapper(container, new PolyphonyFubuRegistry());
            bootstrapper.Bootstrap(routes);
        }

        public static void Bootstrap(RouteCollection routes)
        {
            new FubuStructureMapBootstrapper(routes).BootstrapStructureMap();
        }
    }
}