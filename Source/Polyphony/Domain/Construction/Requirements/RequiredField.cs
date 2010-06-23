using System;
using System.Linq.Expressions;

namespace Polyphony.Domain.Construction.Requirements
{
    public class RequiredField<TSubject> : BaseBuildRequirement<TSubject, object>
    {
        public RequiredField(TSubject subject, Expression<Func<TSubject, object>> expression)
            : base(subject, expression)
        {
        }

        public override void Validate()
        {
            var property = FieldSpecifier.Field;
            

            if(property == null)
            {
                throw new BuilderException(FieldSpecifier.Subject, "Required field was null.");
            }

            var type = property.GetType();
            if(!type.IsValueType)
            {
                return;
            }

            var defaultValue = Activator.CreateInstance(type);
            if(defaultValue.Equals(property))
            {
                var prop = FieldSpecifier.Expression.FindProperty();
                string msg = "Required field missing";
                if(prop != null)
                {
                    msg = String.Format("Required field missing: {0}", prop.Name);
                }

                throw new BuilderException(FieldSpecifier.Subject, msg);
            }
        }
    }
}