using System.Reflection;
using FubuMVC.Core.Registration.Nodes;
using NUnit.Framework;
using Polyphony.Web.Endpoints;
using Polyphony.Web.Endpoints.Users;

namespace Polyphony.Tests.Web.Policies
{
    [TestFixture]
    public class when_building_endpoint_urls : InteractionContext<EndpointUrlPolicy>
    {
        private ActionCall _endpointCall;
        private ActionCall _dummyLambdaCall;
        protected override void BeforeEach()
        {
            var endpointType = typeof(ListEndpoint);
            _endpointCall = new ActionCall(endpointType, endpointType.GetMethod("Get", BindingFlags.Instance | BindingFlags.Public));
            _dummyLambdaCall = ActionCall.For<when_building_endpoint_urls>(t => t);
        }

        [Test]
        public void endpoint_handlers_are_matched()
        {
            ClassUnderTest
                .Matches(_endpointCall, null)
                .ShouldBeTrue();
        }

        [Test]
        public void non_endpoint_handlers_are_not_matched()
        {
            ClassUnderTest
                .Matches(_dummyLambdaCall, null)
                .ShouldBeFalse();
        }

        [Test]
        public void single_namespace_results_in_namesplace_slash_endpoint_name()
        {
            ClassUnderTest
                .Build(_endpointCall)
                .ToRoute()
                .Url
                .ShouldEqual("users/list");
        }

        #region Nested Types
        public class DummyModel
        {
        }
        #endregion
    }
}