using System;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using Polyphony.Domain.Construction;
using Polyphony.Domain.Construction.Requirements;

namespace Polyphony.Domain.Requirements
{
    public class PhoneNumberRequirement<T> : BaseBuildRequirement<T, string>
    {
        private static readonly Regex PhoneNumberExp;
        static PhoneNumberRequirement()
        {
            PhoneNumberExp = new Regex("[0-9]{10}", RegexOptions.Compiled);
        }
        public PhoneNumberRequirement(T subject, Expression<Func<T, string>> expression)
            : base(subject, expression)
        {
        }
        public override void Validate()
        {
            var phoneNr = FieldSpecifier.Field;
            if(PhoneNumberExp.IsMatch(phoneNr))
            {
                return;
            }

            throw new BuilderException(FieldSpecifier.Subject, string.Format("Invalid phone number specified: \"{0}\"", phoneNr));
        }
    }
}