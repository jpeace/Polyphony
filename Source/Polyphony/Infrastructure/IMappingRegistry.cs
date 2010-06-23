using System;

namespace Polyphony.Infrastructure
{
	/// <summary>
	/// Provides a registry for mapping specifications.
	/// </summary>
	public interface IMappingRegistry
	{
		/// <summary>
		/// Maps the source object to the specified destination type.
		/// </summary>
		/// <typeparam name="TSource"></typeparam>
		/// <typeparam name="TDestination"></typeparam>
		/// <param name="source"></param>
		/// <returns></returns>
		TDestination Map<TSource, TDestination>(TSource source) where TDestination : class;

		/// <summary>
		/// Maps the source object to the specified destination type.
		/// </summary>
		/// <param name="destinationType"></param>
		/// <param name="source"></param>
		/// <param name="sourceType"></param>
		/// <returns></returns>
		object Map(Type sourceType, Type destinationType, object source);

		/// <summary>
		/// Maps the source object to the specified destination type.
		/// </summary>
		/// <typeparam name="TSource"></typeparam>
		/// <typeparam name="TDestination"></typeparam>
		/// <typeparam name="TChainDestination"></typeparam>
		/// <param name="source"></param>
		/// <returns></returns>
		TChainDestination Map<TSource, TDestination, TChainDestination>(TSource source);
	}
}
