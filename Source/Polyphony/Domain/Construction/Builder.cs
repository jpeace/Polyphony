using System;
using System.Linq.Expressions;
using System.Reflection;
using Builder;

namespace Polyphony.Domain.Construction
{
    public abstract class Builder<TSubject>
        where TSubject : class
    {
        protected readonly TSubject Subject;
        private readonly BuildValidator<TSubject> _buildValidator;
        protected Builder()
        {
            var subjectType = typeof (TSubject);
            var ctors = subjectType.GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance);
            Subject = (TSubject) ctors[0].Invoke(null);

            _buildValidator = new BuildValidator<TSubject>(Subject); //TODO: Consolidate these new operations (DRY violation)
        }

        protected Builder(TSubject subject)
        {
            Subject = subject;
            _buildValidator = new BuildValidator<TSubject>(Subject);
        }

        public void SetBuildRequirements(Action<BuildValidator<TSubject>> requirements)
        {
            requirements(_buildValidator);
        }

        protected void SetSubjectProperty<TField>(Expression<Func<TSubject, TField>> expression, object value)
        {
            var memberExpression = expression.Body as MemberExpression;
            if(memberExpression == null)
            {
                throw new ArgumentException("Invalid expression - not a member access.", "expression");
            }

            while(true)
            {
                var tmpExpression = memberExpression.Expression as MemberExpression;
                if (tmpExpression != null)
                {
                    memberExpression = tmpExpression;
                    continue;
                }

                break;
            }

            var propertyInfo = memberExpression.Member as PropertyInfo;
            if(propertyInfo != null)
            {
                propertyInfo.SetValue(Subject, value, BindingFlags.NonPublic | BindingFlags.Instance, null, null, null);
                return;
            }

            var fieldInfo = memberExpression.Member as FieldInfo;
            if (fieldInfo != null)
            {
                fieldInfo.SetValue(Subject, value, BindingFlags.NonPublic | BindingFlags.Instance, null, null);
                return;
            }
        }

        public TSubject Build()
        {
            _buildValidator.Validate();
            return Subject;
        }
    }
}