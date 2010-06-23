using NHibernate;
using NUnit.Framework;
using StructureMap;

namespace Polyphony.IntegrationTests
{
    public abstract class IntegrationContext<TEntity, TClassUnderTest>
        where TEntity : class
        where TClassUnderTest : class
    {
        private IContainer _container;
        private EntityConfigurationExpression<TEntity> _entityConfigurationExpression;
        private TEntity _entity;
        private TClassUnderTest _classUnderTest;
        [TestFixtureSetUp]
        public void SetUpContext()
        {
            // Integration registry registers fluent configuration
            _container = new Container(x => x.AddRegistry<IntegrationRegistry>());
            _container.Configure(ConfigureStructureMap);

            BeforeAll();

            _entityConfigurationExpression = new EntityConfigurationExpression<TEntity>();
            
            Configure(_entityConfigurationExpression);

            using (var session = _container.GetInstance<ISession>())
            {
                session.Save(Entity);
                session.Flush();
            }
        }

        protected IContainer Container { get { return _container; } }

        protected TEntity Entity
        {
            get
            {
                return _entity ?? (_entity = _entityConfigurationExpression.BuildEntity());
            }
        }

        protected virtual void ConfigureStructureMap(ConfigurationExpression expression)
        {
        }

        protected abstract void Configure(IEntityConfigurationExpression<TEntity> expression);

        /// <summary>
        /// Called by the NUnit framework to perform setup tasks.
        /// Context-specific setup tasks should be implemented by overriding the <see cref="BeforeEach"/> method.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            BeforeEach();
        }
        /// <summary>
        /// Called after setup tasks are performed in the <see cref="SetUpContext"/> method.
        /// </summary>
        protected virtual void BeforeAll()
        {
        }
        /// <summary>
        /// Called after setup tasks are performed in the <see cref="SetUp"/> method.
        /// </summary>
        protected virtual void BeforeEach()
        {
        }

        /// <summary>
        /// Gets the instance of the class being testing.
        /// </summary>
        public TClassUnderTest ClassUnderTest
        {
            get { return _classUnderTest ?? (_classUnderTest = Container.GetInstance<TClassUnderTest>()); }
        }

        [TestFixtureTearDown]
        public void TearDown()
        {
            using (var session = _container.GetInstance<ISession>())
            {
                session.Delete(Entity);
                session.Flush();
            }
        }
    }
}