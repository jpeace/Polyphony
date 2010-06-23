using System;
using NHibernate;
using NHibernate.Criterion;
using NUnit.Framework;
using StructureMap;

namespace Polyphony.IntegrationTests.DomainPersistence
{
    public abstract class EntityPersistenceContext<TEntity>
        where TEntity : class
    {
        private IContainer _container;
        private EntityConfigurationExpression<TEntity> _entityConfigurationExpression;
        private TEntity _entity;
        [TestFixtureSetUp]
        public void SetUpContext()
        {
            // Integration registry registers fluent configuration
            _container = new Container(x => x.AddRegistry<IntegrationRegistry>());

            _entityConfigurationExpression = new EntityConfigurationExpression<TEntity>();
            Configure(_entityConfigurationExpression);
        }

        protected abstract void Configure(IEntityConfigurationExpression<TEntity> expression);

        // NOTE -- virtual to allow for automated verification via random value generators
        protected virtual void VerifyValues(IEntitySpecification<TEntity> specification)
        {
            
        }

        protected TEntity Entity
        {
            get
            {
                return _entity ?? (_entity = _entityConfigurationExpression.BuildEntity());
            }
        }

        protected object EntityId
        {
            get
            {
                return _entityConfigurationExpression.GetEntityId(Entity);
            }
        }

        [Test]
        public void entity_is_persisted_and_retrieved()
        {
            using(var session = _container.GetInstance<ISession>())
            {
                session.Save(Entity);
                session.Flush();
            }

            TEntity entity;
            using (var session = _container.GetInstance<ISession>())
            {
                entity = session.Get<TEntity>(EntityId);
                if (entity == null)
                {
                    Assert.Fail("Entity could not be found.");
                }

                var specification = new EntitySpecification<TEntity>(entity);
                VerifyValues(specification);

                session.Flush();
            }
            

            using (var session = _container.GetInstance<ISession>())
            {
                session.Delete(entity);
                session.Flush();
            }

            using (var session = _container.GetInstance<ISession>())
            {
                var newEntity = session.Get<TEntity>(EntityId);
                if (newEntity != null)
                {
                    Assert.Fail("Unable to delete entity.");
                }

                session.Flush();
            }
        }
    }
}