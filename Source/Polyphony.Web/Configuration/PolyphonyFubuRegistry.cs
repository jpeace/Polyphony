using System;
using System.Collections.Generic;
using FubuMVC.Core;
using FubuMVC.UI;
using FubuMVC.UI.Configuration;
using Polyphony.Web.Endpoints;

namespace Polyphony.Web.Configuration
{
    public class PolyphonyFubuRegistry : FubuRegistry
    {
        public PolyphonyFubuRegistry()
        {
            IncludeDiagnostics(true);

            Applies
                .ToThisAssembly();

            var httpVerbs = new HashSet<string>(StringComparer.InvariantCultureIgnoreCase) { "GET", "POST", "PUT", "HEAD" };

            Actions
                .IncludeTypes(t => t.Namespace.StartsWith(typeof (EndpointUrlPolicy).Namespace) && t.Name.EndsWith("Endpoint"))
                .IncludeMethods(action => httpVerbs.Contains(action.Method.Name));

            httpVerbs
                .Each(verb => Routes.ConstrainToHttpMethod(action => action.Method.Name.Equals(verb, StringComparison.InvariantCultureIgnoreCase), verb));

            Views
                .TryToAttach(findViews => findViews.by_ViewModel());

            Routes
                .UrlPolicy<EndpointUrlPolicy>();

            Output
                .ToJson
                .WhenCallMatches(c => c.OutputType().Name.StartsWith("Ajax"));

            this.UseDefaultHtmlConventions();
        }
    }
}