using System;
using System.Linq.Expressions;
using System.Reflection;
using Polyphony.Domain.Construction;

namespace Polyphony.IntegrationTests
{
    public class EntityConfigurationExpression<TEntity> : IEntityConfigurationExpression<TEntity>
        where TEntity : class
    {
        private EntityBuilder<TEntity> _entityBuilder;
        private PropertyInfo _identifier;
        public IEntityConfigurationExpression<TEntity> IdentifyBy<TPropertyType>(Expression<Func<TEntity, TPropertyType>> property)
        {
            _identifier = property.FindProperty() as PropertyInfo;
            return this;
        }

        public IEntityConfigurationExpression<TEntity> IdentifyBy(string propertyName)
        {
            _identifier = typeof (TEntity)
                .GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            return this;
        }

        public void BuildEntityWith(EntityBuilder<TEntity> entityBuilder)
        {
            _entityBuilder = entityBuilder;
        }

        public TEntity BuildEntity()
        {
            return _entityBuilder();
        }

        public object GetEntityId(TEntity instance)
        {
            if(_identifier == null)
            {
                throw new InvalidOperationException("No identifer was specified.");
            }

            return _identifier.GetValue(instance, null);
        }
    }
}