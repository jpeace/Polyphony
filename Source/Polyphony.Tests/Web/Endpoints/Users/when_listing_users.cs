using System.Collections.Generic;
using NUnit.Framework;
using Polyphony.Domain;
using Polyphony.Infrastructure;
using Polyphony.Repositories;
using Polyphony.Web.Endpoints.Users;
using Polyphony.Web.Models.Users;
using Rhino.Mocks;

namespace Polyphony.Tests.Web.Endpoints.Users
{
    [TestFixture]
    public class when_listing_users : InteractionContext<ListEndpoint>
    {
        [Test]
        public void users_are_retrieved_from_repository_and_mapped_through_registry()
        {
            MockFor<IUserRepository>()
                .Expect(r => r.GetAll())
                .Return(new List<User>
                            {
                                new User { FirstName = "Test 1"},
                                new User { FirstName = "Test 2"}
                            });

            MockFor<IMappingRegistry>()
                .Expect(m => m.Map<User, UserDetailsModel>(Arg<User>.Is.NotNull))
                .Return(new UserDetailsModel())
                .Repeat
                .Twice();

            var listModel = ClassUnderTest.Get();

            listModel.ShouldNotBeNull();
            listModel
                .Users
                .ShouldNotBeEmpty();

            VerifyCallsFor<IUserRepository>();
            VerifyCallsFor<IMappingRegistry>();
        }
    }
}