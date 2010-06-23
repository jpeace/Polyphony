using Polyphony.Domain.Construction;
using Polyphony.Domain.Expressions;
using Polyphony.Domain.Requirements;

namespace Polyphony.Domain.Builders
{
    public class PhoneNumberBuilder : Builder<PhoneNumber>, IPhoneNumberExpression
    {
        public PhoneNumberBuilder(User user)
        {
            SetSubjectProperty(p => p.User, user);
            SetBuildRequirements(r =>
            {
                r.Require(n => n.Value);
                r.Require(n => n.PhoneNumberType);
                r.Require(n => n.User);
                r.AddRequirement(new PhoneNumberRequirement<PhoneNumber>(Subject, n => n.Value));
            });
        }

        public IPhoneNumberExpression WithValue(string phoneNumberValue)
        {
            SetSubjectProperty(p => p.Value, phoneNumberValue);
            return this;
        }

        public IPhoneNumberExpression WithType(PhoneNumberType phoneNumberType)
        {
            SetSubjectProperty(p => p.PhoneNumberType, phoneNumberType);
            return this;
        }
    }
}