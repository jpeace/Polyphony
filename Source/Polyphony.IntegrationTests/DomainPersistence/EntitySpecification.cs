using System.Collections.Generic;

namespace Polyphony.IntegrationTests.DomainPersistence
{
    public class EntitySpecification<TEntity> : IEntitySpecification<TEntity>
        where TEntity : class
    {
        private readonly TEntity _entity;
        private readonly IList<IEntitySpecificationRule<TEntity>> _rules;
        public EntitySpecification(TEntity entity)
        {
            _entity = entity;
            _rules = new List<IEntitySpecificationRule<TEntity>>();
        }

        public IEntitySpecification<TEntity> AddRule(IEntitySpecificationRule<TEntity> rule)
        {
            _rules.Add(rule);
            return this;
        }

        public void Verify()
        {
            foreach (var rule in _rules)
            {
                rule.Execute(_entity);
            }
        }
    }
}