using System;
using System.Linq.Expressions;

namespace Polyphony.Domain.Construction
{
    public class FieldSpecifier<TSubject,TPropertyType>
    {
        private readonly Func<TSubject, TPropertyType> _compiledExpression;
        public FieldSpecifier(TSubject subject, Expression<Func<TSubject, TPropertyType>> expression)
        {
            Subject = subject;
            Expression = expression;

            _compiledExpression = expression.Compile();
        }

        public TSubject Subject { get; private set; }
        public Expression<Func<TSubject, TPropertyType>> Expression { get; private set; }

        public TPropertyType Field
        {
            get
            {
                return _compiledExpression.Invoke(Subject);
            }
        }
    }
}