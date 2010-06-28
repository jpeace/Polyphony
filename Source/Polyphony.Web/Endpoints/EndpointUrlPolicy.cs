using System;
using System.Text;
using FubuMVC.Core.Diagnostics;
using FubuMVC.Core.Registration.Conventions;
using FubuMVC.Core.Registration.Nodes;
using FubuMVC.Core.Registration.Routes;

namespace Polyphony.Web.Endpoints
{
    /// <summary>
    /// Provides a policy for specifying RESTful endpoints.
    /// </summary>
    public class EndpointUrlPolicy : IUrlPolicy
    {
        private const string EndpointString = "Endpoint";
        /// <summary>
        /// Returns a flag indicating whether the policy matches the specified action call.
        /// </summary>
        /// <param name="call"></param>
        /// <param name="log"></param>
        /// <returns></returns>
        public bool Matches(ActionCall call, IConfigurationObserver log)
        {
            return call.HandlerType.Name.EndsWith(EndpointString);
        }
        /// <summary>
        /// Builds a route definition for the specified call.
        /// </summary>
        /// <param name="call"></param>
        /// <returns></returns>
        public IRouteDefinition Build(ActionCall call)
        {
            var routeDefinition = call.ToRouteDefinition();

            var strippedNamespace = call
                                        .HandlerType
                                        .Namespace
                                        .Replace(GetType().Namespace + ".", string.Empty);

            if(!strippedNamespace.Contains("."))
            {
                routeDefinition.Append(BreakUpCamelCaseWithHypen(strippedNamespace));
            }
            else
            {
                var patternParts = strippedNamespace.Split(new[] {"."}, StringSplitOptions.None);
                foreach (var patternPart in patternParts)
                {
                    routeDefinition.Append(BreakUpCamelCaseWithHypen(patternPart.Trim()));
                }
            }

            routeDefinition.Append(BreakUpCamelCaseWithHypen(call.HandlerType.Name.Replace(EndpointString, string.Empty)));
            return routeDefinition;
        }
        /// <summary>
        /// Helper method to build the proper route definition.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private static string BreakUpCamelCaseWithHypen(string input)
        {
            var routeBuilder = new StringBuilder();
            for (int i = 0; i < input.Length; ++i)
            {
                if (i != 0 && char.IsUpper(input[i]))
                {
                    routeBuilder.Append("-");
                }

                routeBuilder.Append(input[i]);
            }

            return routeBuilder
                        .ToString()
                        .ToLower();
        }
    }
}