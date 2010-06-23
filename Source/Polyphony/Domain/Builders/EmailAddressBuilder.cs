using Polyphony.Domain.Construction;
using Polyphony.Domain.Expressions;
using Polyphony.Domain.Requirements;

namespace Polyphony.Domain.Builders
{
    public class EmailAddressBuilder : Builder<EmailAddress>, IEmailAddressExpression
    {
        public EmailAddressBuilder(User user)
        {
            SetSubjectProperty(p => p.User, user);
            SetBuildRequirements(r =>
            {
                r.Require(n => n.Value);
                r.Require(n => n.EmailType);
                r.Require(n => n.User);
                r.AddRequirement(new EmailAddressRequirement<EmailAddress>(Subject, n => n.Value));
            });
        }

        public IEmailAddressExpression WithValue(string emailAddressValue)
        {
            SetSubjectProperty(s => s.Value, emailAddressValue);
            return this;
        }

        public IEmailAddressExpression WithType(EmailType emailType)
        {
            SetSubjectProperty(s => s.EmailType, emailType);
            return this;
        }
    }
}