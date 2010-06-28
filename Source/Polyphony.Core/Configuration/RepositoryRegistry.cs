using Polyphony.Core.NHibernate.Repositories;
using Polyphony.Repositories;
using StructureMap.Configuration.DSL;

namespace Polyphony.Core.Configuration
{
	/// <summary>
	/// Provides a common registry mechanism for repository implementations.
	/// </summary>
	public class RepositoryRegistry : Registry
	{
		/// <summary>
        /// Initializes a new instance of the <see cref="RepositoryRegistry"/> class.
		/// </summary>
        public RepositoryRegistry()
		{
            Scan(x =>
                     {
                         x.TheCallingAssembly();
                         x.AssemblyContainingType<RepositoryMarker>();
                         x.IncludeNamespaceContainingType<RepositoryMarker>();
                         x.IncludeNamespaceContainingType<CoreRepositoryMarker>();
                         x.WithDefaultConventions();
                     });
		}
	}
}
