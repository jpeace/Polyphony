using System;
using System.Linq.Expressions;

namespace Polyphony.IntegrationTests
{
    public interface IEntityConfigurationExpression<TEntity>
        where TEntity : class
    {
        //TODO -- Some sort of registry system for random value generators. Should allow manual overrides (ala Fubu's HtmlConventions?)
        IEntityConfigurationExpression<TEntity> IdentifyBy<TPropertyType>(Expression<Func<TEntity, TPropertyType>> property);
        IEntityConfigurationExpression<TEntity> IdentifyBy(string propertyName);
        void BuildEntityWith(EntityBuilder<TEntity> entityBuilder);
    }
}