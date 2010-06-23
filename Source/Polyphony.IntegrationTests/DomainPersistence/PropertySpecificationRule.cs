using System;
using System.Linq.Expressions;
using System.Reflection;
using Polyphony.Domain.Construction;
using Polyphony.Tests;

namespace Polyphony.IntegrationTests.DomainPersistence
{
    public class PropertySpecificationRule<TEntity, TPropertyType> : IEntitySpecificationRule<TEntity>
        where TEntity : class
    {
        private readonly Expression<Func<TEntity, TPropertyType>> _property;
        private readonly TPropertyType _expectedValue;

        public PropertySpecificationRule(Expression<Func<TEntity, TPropertyType>> property, TPropertyType expectedValue)
        {
            _property = property;
            _expectedValue = expectedValue;
        }

        public void Execute(TEntity entity)
        {
            var property = _property.FindProperty() as PropertyInfo;
            if(property == null)
            {
                throw new InvalidOperationException("Invalid expression specified.");
            }

            property
                .GetValue(entity, null)
                .ShouldEqual(_expectedValue);
        }
    }
}