using System.Web;
using System.Web.Routing;
using Polyphony.Web.Configuration;

namespace Polyphony.Web
{
    public class MvcApplication : HttpApplication
    {

        protected void Application_Start()
        {
            FubuStructureMapBootstrapper.Bootstrap(RouteTable.Routes);
        }
    }
}