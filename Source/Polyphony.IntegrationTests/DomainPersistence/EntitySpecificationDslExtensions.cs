using System;
using System.Linq.Expressions;

namespace Polyphony.IntegrationTests.DomainPersistence
{
    public static class EntitySpecificationDslExtensions
    {
        public static IEntitySpecification<TEntity> CheckProperty<TEntity, TPropertyType>(this IEntitySpecification<TEntity> specification,
                                                                                          Expression<Func<TEntity, TPropertyType>> property, TPropertyType expected) where TEntity : class
        {
            specification.AddRule(new PropertySpecificationRule<TEntity, TPropertyType>(property, expected));
            return specification;
        }

        public static IEntitySpecification<TEntity> Check<TEntity>(this IEntitySpecification<TEntity> specification, Func<TEntity, bool> action, 
            string errorMsg) where TEntity : class
        {
            specification.AddRule(new LambdaSpecificationRule<TEntity>(action, errorMsg));
            return specification;
        }
    }
}