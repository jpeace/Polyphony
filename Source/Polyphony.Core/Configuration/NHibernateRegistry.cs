using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using Polyphony.Core.Infrastructure;
using Polyphony.Core.NHibernate.Mappings;
using Polyphony.Core.NHibernate.Repositories;
using Polyphony.Infrastructure;
using Polyphony.Repositories;
using StructureMap.Configuration.DSL;

namespace Polyphony.Core.Configuration
{
	/// <summary>
	/// Provides a common registry mechanism for NHibernate implementations of the infrastructure layer.
	/// </summary>
	public class NHibernateRegistry : Registry
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="NHibernateRegistry"/> class.
		/// </summary>
		public NHibernateRegistry()
		{
			//TODO: Configurable connection string? (ISettingsProvider)
            var sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008.ConnectionString(c => c.FromConnectionStringWithKey("Polyphony")))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<MapMarker>())
				.ExposeConfiguration(cfg => For<global::NHibernate.Cfg.Configuration>().Singleton().Use(cfg))
                .BuildSessionFactory();

			For<ISessionFactory>()
                .Singleton()
                .Use(sessionFactory);

			For<ISession>()
				.Use(ctx => ctx.GetInstance<ISessionFactory>().OpenSession());

            Scan(x =>
                     {
                         x.TheCallingAssembly();
                         x.AssemblyContainingType<IUnitOfWork>();
                         x.IncludeNamespaceContainingType<IUnitOfWork>();
                         x.IncludeNamespaceContainingType<UnitOfWork>();
                         x.WithDefaultConventions();
                     });
		}
	}
}
