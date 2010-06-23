using System;
using System.Linq.Expressions;

namespace Polyphony.Domain.Construction.Requirements
{
    public class PositiveNumberField<TSubject> : BaseBuildRequirement<TSubject, int>
    {
        public PositiveNumberField(TSubject subject, Expression<Func<TSubject, int>> expression)
            : base(subject, expression)
        {
        }

        public override void Validate()
        {
            var num = FieldSpecifier.Field;
            if (num <= 0)
            {
                throw new BuilderException(FieldSpecifier.Subject, String.Format("Positive number field is {0}", num));
            }
        }
    }
}