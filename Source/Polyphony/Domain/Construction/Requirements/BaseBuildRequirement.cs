using System;
using System.Linq.Expressions;

namespace Polyphony.Domain.Construction.Requirements
{
    public abstract class BaseBuildRequirement<TSubject, TField> : IBuildRequirement
    {
        protected readonly FieldSpecifier<TSubject, TField> FieldSpecifier;

        protected BaseBuildRequirement(TSubject subject, Expression<Func<TSubject, TField>> expression)
        {
            FieldSpecifier = new FieldSpecifier<TSubject, TField>(subject, expression);
        }

        public abstract void Validate();
    }
}