using System;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using Polyphony.Domain.Construction;
using Polyphony.Domain.Construction.Requirements;

namespace Polyphony.Domain.Requirements
{
    public class EmailAddressRequirement<T> : BaseBuildRequirement<T, string>
    {
        private static readonly Regex EmailExp;
        static EmailAddressRequirement()
        {
            EmailExp = new Regex(@"^((?:(?:(?:[a-zA-Z0-9][\.\-\+_]?)*)[a-zA-Z0-9])+)\@((?:(?:(?:[a-zA-Z0-9][\.\-_]?){0,62})[a-zA-Z0-9])+)\.([a-zA-Z0-9]{2,6})$", RegexOptions.Compiled);
        }
        public EmailAddressRequirement(T subject, Expression<Func<T, string>> expression)
            : base(subject, expression)
        {
        }
        public override void Validate()
        {
            var emailAddress = FieldSpecifier.Field;
            if(EmailExp.IsMatch(emailAddress))
            {
                return;
            }

            throw new BuilderException(FieldSpecifier.Subject, string.Format("Invalid email address specified: \"{0}\"", emailAddress));
        }
    }
}