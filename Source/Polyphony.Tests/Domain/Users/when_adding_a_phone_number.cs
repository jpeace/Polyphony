using System.Linq;
using NUnit.Framework;
using Polyphony.Domain;
using Polyphony.Domain.Construction;

namespace Polyphony.Tests.Domain.Users
{
    [TestFixture]
    public class when_adding_a_phone_number
    {
        private User _subject;
        private const string ValidPhoneNr = "5126852220";
        [SetUp]
        public void SetUp()
        {
            _subject = new User();
        }

        [Test]
        public void an_exception_is_thrown_if_the_value_is_not_specified()
        {
            Exception<BuilderException>
                .ShouldBeThrownBy(() => _subject.AddPhoneNumber(p => { }));
        }

        [Test]
        public void an_exception_is_thrown_if_the_value_specified_is_invalid()
        {
            var exc = Exception<BuilderException>.ShouldBeThrownBy(() => _subject.AddPhoneNumber(p => p.WithValue("123").WithType(PhoneNumberType.Home)));
            exc.Message.ShouldContain("123");
        }

        [Test]
        public void an_exception_is_thrown_if_the_type_is_not_specified()
        {
            var exc = Exception<BuilderException>.ShouldBeThrownBy(() => _subject.AddPhoneNumber(p => p.WithValue(ValidPhoneNr)));
            exc.Message.ShouldContain("PhoneNumberType");
        }

        [Test]
        public void phone_number_is_added_if_valid()
        {
            _subject.AddPhoneNumber(p => p.WithValue(ValidPhoneNr).WithType(PhoneNumberType.Home));
            _subject
                .PhoneNumbers
                .First()
                .Value
                .ShouldBeTheSameAs(ValidPhoneNr);
        }
    }
}