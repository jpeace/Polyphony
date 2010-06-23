using System.Linq;
using NUnit.Framework;
using Polyphony.Domain;

namespace Polyphony.IntegrationTests.DomainPersistence
{
    [TestFixture]
    public class UserPersistenceTester : EntityPersistenceContext<User>
    {
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

        protected override void VerifyValues(IEntitySpecification<User> specification)
        {
            specification
                .CheckProperty(u => u.FirstName, "Test")
                .CheckProperty(u => u.LastName, "User")
                .Check(u => u.EmailAddresses.Count() == 1 && u.EmailAddresses.First().Value.Equals("test@proace.com"), "Email addresses do not match")
                .Check(u => u.PhoneNumbers.Count() == 1 && u.PhoneNumbers.First().Value.Equals("5126852220"), "Phone numbers do not match")
                .Verify();
        }
    }
}