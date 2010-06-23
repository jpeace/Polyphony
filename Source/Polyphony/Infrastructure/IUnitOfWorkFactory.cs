namespace Polyphony.Infrastructure
{
	/// <summary>
	/// Provides a factory for the <see cref="IUnitOfWork"/> interface.
	/// </summary>
	public interface IUnitOfWorkFactory
	{
		/// <summary>
		/// Creates a new unit of work.
		/// </summary>
		/// <returns></returns>
		IUnitOfWork CreateInstance();
	}
}
