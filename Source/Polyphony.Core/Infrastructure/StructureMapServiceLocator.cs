using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.ServiceLocation;
using StructureMap;

namespace Polyphony.Core.Infrastructure
{
	/// <summary>
	/// StructureMap adapater for the <see cref="IServiceLocator"/> contract.
	/// </summary>
	public class StructureMapServiceLocator : IServiceLocator
	{
		private readonly IContainer _container;
		/// <summary>
		/// Initializes a new instance of the <see cref="StructureMapServiceLocator"/> class.
		/// </summary>
		/// <param name="container">The underlying StructureMap container.</param>
		public StructureMapServiceLocator(IContainer container)
		{
			_container = container;
		}

		/// <summary>
		/// Gets the service object of the specified type.
		/// </summary>
		/// <returns>
		/// A service object of type <paramref name="serviceType"/>.
		///                     -or- 
		///                 null if there is no service object of type <paramref name="serviceType"/>.
		/// </returns>
		/// <param name="serviceType">An object that specifies the type of service object to get. 
		///                 </param><filterpriority>2</filterpriority>
		public object GetService(Type serviceType)
		{
			return _container.GetInstance(serviceType);
		}

		/// <summary>
		/// Get an instance of the given <paramref name="serviceType"/>.
		/// </summary>
		/// <param name="serviceType">Type of object requested.</param><exception cref="T:Microsoft.Practices.ServiceLocation.ActivationException">if there is an error resolving
		///             the service instance.</exception>
		/// <returns>
		/// The requested service instance.
		/// </returns>
		public object GetInstance(Type serviceType)
		{
			return _container.GetInstance(serviceType);
		}

		/// <summary>
		/// Get an instance of the given named <paramref name="serviceType"/>.
		/// </summary>
		/// <param name="serviceType">Type of object requested.</param><param name="key">Name the object was registered with.</param><exception cref="T:Microsoft.Practices.ServiceLocation.ActivationException">if there is an error resolving
		///             the service instance.</exception>
		/// <returns>
		/// The requested service instance.
		/// </returns>
		public object GetInstance(Type serviceType, string key)
		{
			return _container.GetInstance(serviceType, key);
		}

		/// <summary>
		/// Get all instances of the given <paramref name="serviceType"/> currently
		///             registered in the container.
		/// </summary>
		/// <param name="serviceType">Type of object requested.</param><exception cref="T:Microsoft.Practices.ServiceLocation.ActivationException">if there is are errors resolving
		///             the service instance.</exception>
		/// <returns>
		/// A sequence of instances of the requested <paramref name="serviceType"/>.
		/// </returns>
		public IEnumerable<object> GetAllInstances(Type serviceType)
		{
			return _container.GetAllInstances(serviceType).Cast<object>();
		}

		/// <summary>
		/// Get an instance of the given <typeparamref name="TService"/>.
		/// </summary>
		/// <typeparam name="TService">Type of object requested.</typeparam><exception cref="T:Microsoft.Practices.ServiceLocation.ActivationException">if there is are errors resolving
		///             the service instance.</exception>
		/// <returns>
		/// The requested service instance.
		/// </returns>
		public TService GetInstance<TService>()
		{
			return _container.GetInstance<TService>();
		}

		/// <summary>
		/// Get an instance of the given named <typeparamref name="TService"/>.
		/// </summary>
		/// <typeparam name="TService">Type of object requested.</typeparam><param name="key">Name the object was registered with.</param><exception cref="T:Microsoft.Practices.ServiceLocation.ActivationException">if there is are errors resolving
		///             the service instance.</exception>
		/// <returns>
		/// The requested service instance.
		/// </returns>
		public TService GetInstance<TService>(string key)
		{
			return _container.GetInstance<TService>(key);
		}

		/// <summary>
		/// Get all instances of the given <typeparamref name="TService"/> currently
		///             registered in the container.
		/// </summary>
		/// <typeparam name="TService">Type of object requested.</typeparam><exception cref="T:Microsoft.Practices.ServiceLocation.ActivationException">if there is are errors resolving
		///             the service instance.</exception>
		/// <returns>
		/// A sequence of instances of the requested <typeparamref name="TService"/>.
		/// </returns>
		public IEnumerable<TService> GetAllInstances<TService>()
		{
			return _container.GetAllInstances<TService>();
		}
	}
}
