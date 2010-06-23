using System.Linq;
using AutoMapper;
using Microsoft.Practices.ServiceLocation;
using NUnit.Framework;
using Polyphony.Core.Infrastructure;
using Polyphony.Domain;
using Polyphony.Infrastructure;
using Polyphony.Tests;
using Polyphony.Web.Infrastructure.Mappers;
using Polyphony.Web.Models.Users;
using StructureMap;

namespace Polyphony.IntegrationTests.Web.ModelMappings
{
    [TestFixture]
    public class when_mapping_user_to_user_details
    {
        private IMappingRegistry _mappingRegistry;
        [SetUp]
        public void SetUp()
        {
            ObjectFactory.Initialize(x => { });
            ServiceLocator.SetLocatorProvider(() => new StructureMapServiceLocator(ObjectFactory.Container));
            Mapper.Initialize(x => x.IncludeMap<UserToUserDetailsMapper>());
            _mappingRegistry = new AutoMapperMappingRegistry(Mapper.Engine);
        }
        [Test]
        public void all_properties_match_the_source()
        {
            var user = new User
                           {
                               FirstName = "Test",
                               LastName = "User"
                           };
            user.AddPhoneNumber(p => p.WithValue("5126852220").WithType(PhoneNumberType.Home));
            user.AddEmailAddress(p => p.WithValue("test@proace.com").WithType(EmailType.Home));

            var detailsModel = _mappingRegistry.Map<User, UserDetailsModel>(user);

            detailsModel
                .FirstName
                .ShouldEqual(user.FirstName);

            detailsModel
                .LastName
                .ShouldEqual(user.LastName);

            detailsModel
                .EmailAddresses
                .ShouldHaveCount(1);

            detailsModel
                .EmailAddresses
                .First()
                .Value
                .ShouldEqual("test@proace.com");

            detailsModel
                .PhoneNumbers
                .ShouldHaveCount(1);

            detailsModel
                .PhoneNumbers
                .First()
                .Value
                .ShouldEqual("5126852220");
        }
    }
}