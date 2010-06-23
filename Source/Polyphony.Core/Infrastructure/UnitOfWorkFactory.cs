using Polyphony.Infrastructure;
using StructureMap;

namespace Polyphony.Core.Infrastructure
{
	/// <summary>
	/// Provides a factory for the <see cref="IUnitOfWork"/> interface.
	/// </summary>
	public class UnitOfWorkFactory : IUnitOfWorkFactory
	{
		private readonly IContainer _container;
		/// <summary>
		/// Initializes a new instance of the <see cref="UnitOfWorkFactory"/> class.
		/// </summary>
		/// <param name="container">The configured container.</param>
		public UnitOfWorkFactory(IContainer container)
		{
			_container = container;
		}

		/// <summary>
		/// Creates a new unit of work.
		/// </summary>
		/// <returns></returns>
		public IUnitOfWork CreateInstance()
		{
			return _container.GetInstance<IUnitOfWork>();
		}
	}
}
