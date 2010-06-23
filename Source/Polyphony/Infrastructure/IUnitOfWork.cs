using System;

namespace Polyphony.Infrastructure
{
	/// <summary>
	/// Maintains a list of objects affected by a business transaction and coordinates the writing out of changes and the resolution of concurrency problems.
	/// </summary>
	public interface IUnitOfWork : IDisposable
	{
        /// <summary>
        /// Initializes the unit of work.
        /// </summary>
	    void Initialize();
		/// <summary>
		/// Marks the specified entity to be inserted.
		/// </summary>
		/// <param name="entity">Entity to insert.</param>
		void Insert(object entity);
		/// <summary>
		/// Marks the specified entity to be updated.
		/// </summary>
		/// <param name="entity">Entity to update.</param>
		void Update(object entity);
		/// <summary>
		/// Marks the specified entity to be deleted.
		/// </summary>
		/// <param name="entity"></param>
		void Delete(object entity);
		/// <summary>
		/// Commits the unit of work.
		/// </summary>
		void Commit();
        /// <summary>
        /// Rolls back the unit of work.
        /// </summary>
	    void Rollback();
	}
}
