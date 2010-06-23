using System;
using NHibernate;
using Polyphony.Infrastructure;

namespace Polyphony.Core.Infrastructure
{
	/// <summary>
	/// NHibernate-specific implementation of the <see cref="IUnitOfWork"/> interface that maintains a list of objects affected by a 
	/// business transaction and coordinates the writing out of changes and the resolution of concurrency problems.
	/// </summary>
	public class UnitOfWork : IUnitOfWork
	{
	    private readonly ISessionFactory _sessionFactory;
	    private ITransaction _transaction;
        private bool _isDisposed;
        private bool _isInitialized;
	    private ISession _session;

	    /// <summary>
	    /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
	    /// </summary>
	    /// <param name="sessionFactory"></param>
	    public UnitOfWork(ISessionFactory sessionFactory)
	    {
	        _sessionFactory = sessionFactory;
	    }

	    /// <summary>
	    /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
	    /// </summary>
	    /// <filterpriority>2</filterpriority>
	    public void Dispose()
	    {
            if (_isDisposed || !_isInitialized)
            {
                return;
            }

            _transaction.Dispose();
            _session.Dispose();

            _isDisposed = true;
	    }

	    /// <summary>
	    /// Initializes the unit of work.
	    /// </summary>
	    public void Initialize()
	    {
	        should_not_currently_be_disposed();
	        _session = _sessionFactory.OpenSession();
            begin_new_transaction();

	        _isInitialized = true;
	    }

	    /// <summary>
	    /// Marks the specified entity to be inserted.
	    /// </summary>
	    /// <param name="entity">Entity to insert.</param>
	    public void Insert(object entity)
	    {
	        should_be_initialized_first();
	        _session.Save(entity);
	    }

	    /// <summary>
	    /// Marks the specified entity to be updated.
	    /// </summary>
	    /// <param name="entity">Entity to update.</param>
	    public void Update(object entity)
	    {
            should_be_initialized_first();
            _session.Update(entity);
	    }

	    /// <summary>
	    /// Marks the specified entity to be deleted.
	    /// </summary>
	    /// <param name="entity"></param>
	    public void Delete(object entity)
	    {
            should_be_initialized_first();
            _session.Delete(entity);
	    }

	    /// <summary>
	    /// Commits the unit of work.
	    /// </summary>
	    public void Commit()
	    {
            should_not_currently_be_disposed();
            should_be_initialized_first();

            _transaction.Commit();

            begin_new_transaction();
	    }

	    /// <summary>
	    /// Rolls back the unit of work.
	    /// </summary>
	    public void Rollback()
	    {
            should_not_currently_be_disposed();
            should_be_initialized_first();

            _transaction.Rollback();

            begin_new_transaction();
	    }

        private void begin_new_transaction()
        {
            if (_transaction != null)
            {
                _transaction.Dispose();
            }

            _transaction = _session.BeginTransaction();
        }

        private void should_not_currently_be_disposed()
        {
            if (_isDisposed)
            {
                throw new ObjectDisposedException(GetType().Name);
            }
        }

        private void should_be_initialized_first()
        {
            if (!_isInitialized)
            {
                throw new InvalidOperationException("Must initialize (call Initialize()) on UnitOfWork before operating.");
            }
        }
	}
}
