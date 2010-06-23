using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using Polyphony.Core.NHibernate.Conventions;
using Polyphony.Core.NHibernate.Mappings;
using StructureMap.Configuration.DSL;

namespace Polyphony.IntegrationTests
{
    public class IntegrationRegistry : Registry
    {
        public IntegrationRegistry()
        {
            //var session = MockRepository.GenerateStub<ISession>();
            //session.Expect(s => s.Load<User>(Arg<int>.Is.Anything)).Return(new User());

            //For<ISession>().Use(session);
            var sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008.ConnectionString(c => c.FromConnectionStringWithKey("Polyphony")))
                .Mappings(m =>
                              {
                                  m.FluentMappings.AddFromAssemblyOf<MapMarker>();
                                  m.FluentMappings.Conventions.AddFromAssemblyOf<ConventionMarker>();
                              })
                .ExposeConfiguration(cfg =>
                                         {
                                             //For<global::NHibernate.Cfg.Configuration>().Singleton().Use(cfg);
                                             new SchemaExport(cfg).Create(false, true);
                                         })
                .BuildSessionFactory();

            For<ISessionFactory>()
                .Singleton()
                .Use(sessionFactory);

            For<ISession>()
                .Use(ctx => ctx.GetInstance<ISessionFactory>().OpenSession());
        }
    }
}