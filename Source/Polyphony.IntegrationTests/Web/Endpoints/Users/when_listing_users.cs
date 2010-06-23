using System.Linq;
using AutoMapper;
using Microsoft.Practices.ServiceLocation;
using NUnit.Framework;
using Polyphony.Core.Configuration;
using Polyphony.Core.Infrastructure;
using Polyphony.Domain;
using Polyphony.Infrastructure;
using Polyphony.IntegrationTests.DomainPersistence;
using Polyphony.Web.Endpoints.Users;
using Polyphony.Web.Infrastructure.Mappers;
using Polyphony.Web.Models.Users;

namespace Polyphony.IntegrationTests.Web.Endpoints.Users
{
    [TestFixture]
    public class when_listing_users : IntegrationContext<User, ListEndpoint>
    {
        protected override void ConfigureStructureMap(StructureMap.ConfigurationExpression expression)
        {
            expression.IncludeRegistry<RepositoryRegistry>();
            expression.For<IMappingRegistry>().Use<AutoMapperMappingRegistry>();
        }

        protected override void BeforeAll()
        {
            ServiceLocator.SetLocatorProvider(() => new StructureMapServiceLocator(Container));
            Mapper.Initialize(x => x.IncludeMap<UserToUserDetailsMapper>());

            Container.Configure(x => x.For<IMappingEngine>().Use(Mapper.Engine));
        }

        protected override void Configure(IEntityConfigurationExpression<User> expression)
        {
            expression
                .IdentifyBy(u => u.UserId)
                .BuildEntityWith(() =>
                                        {
                                            var user = new User
                                            {
                                                FirstName = "Test",
                                                LastName = "User"
                                            };

                                            user.AddPhoneNumber(p => p.WithValue("5126852220").WithType(PhoneNumberType.Home));
                                            user.AddEmailAddress(p => p.WithValue("test@proace.com").WithType(EmailType.Home));

                                            return user;
                                        });
        }

        [Test]
        public void user_is_retrieved_from_database_and_mapped_to_details_model()
        {
            var user = ClassUnderTest
                            .Get()
                            .Users
                            .FirstOrDefault();

            var specification = new EntitySpecification<UserDetailsModel>(user);

            specification
                .CheckProperty(u => u.FirstName, "Test")
                .CheckProperty(u => u.LastName, "User")
                .Check(u => u.EmailAddresses.Count() == 1 && u.EmailAddresses.First().Value.Equals("test@proace.com"), "Email addresses do not match")
                .Check(u => u.PhoneNumbers.Count() == 1 && u.PhoneNumbers.First().Value.Equals("5126852220"), "Phone numbers do not match")
                .Verify();
        }
    }
}