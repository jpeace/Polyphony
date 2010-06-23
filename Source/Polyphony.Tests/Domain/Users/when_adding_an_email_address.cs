using System.Linq;
using NUnit.Framework;
using Polyphony.Domain;
using Polyphony.Domain.Construction;

namespace Polyphony.Tests.Domain.Users
{
    [TestFixture]
    public class when_adding_an_email_address
    {
        private User _subject;
        private const string ValidEmail = "test@proace.com";
        [SetUp]
        public void SetUp()
        {
            _subject = new User();
        }

        [Test]
        public void an_exception_is_thrown_if_the_value_is_not_specified()
        {
            Exception<BuilderException>
                .ShouldBeThrownBy(() => _subject.AddEmailAddress(p => { }));
        }

        [Test]
        public void an_exception_is_thrown_if_the_value_specified_is_invalid()
        {
            var exc = Exception<BuilderException>.ShouldBeThrownBy(() => _subject.AddEmailAddress(a => a.WithValue("blah@").WithType(EmailType.Office)));
            exc.Message.ShouldContain("blah@");
        }

        [Test]
        public void an_exception_is_thrown_if_the_type_is_not_specified()
        {
            var exc = Exception<BuilderException>.ShouldBeThrownBy(() => _subject.AddEmailAddress(a => a.WithValue(ValidEmail)));
            exc.Message.ShouldContain("EmailType");
        }

        [Test]
        public void phone_number_is_added_if_valid()
        {
            _subject.AddEmailAddress(a => a.WithValue(ValidEmail).WithType(EmailType.Home));
            _subject
                .EmailAddresses
                .First()
                .Value
                .ShouldBeTheSameAs(ValidEmail);
        }
    }
}