using System;
using AutoMapper;
using Polyphony.Infrastructure;

namespace Polyphony.Core.Infrastructure
{
	/// <summary>
	/// Provides a registry for mapping specifications stored through the AutoMapper framework.
	/// </summary>
	public class AutoMapperMappingRegistry : IMappingRegistry
	{
	    private readonly IMappingEngine _mappingEngine;

	    public AutoMapperMappingRegistry(IMappingEngine mappingEngine)
	    {
	        _mappingEngine = mappingEngine;
	    }

	    /// <summary>
		/// Maps the source object to the specified destination type.
		/// </summary>
		/// <typeparam name="TSource"></typeparam>
		/// <typeparam name="TDestination"></typeparam>
		/// <param name="source"></param>
		/// <returns></returns>
        public TDestination Map<TSource, TDestination>(TSource source) where TDestination : class
		{
            return _mappingEngine.Map<TSource, TDestination>(source);
		}

	    /// <summary>
	    /// Maps the source object to the specified destination type.
	    /// </summary>
	    /// <param name="destinationType"></param>
	    /// <param name="source"></param>
	    /// <param name="sourceType"></param>
	    /// <returns></returns>
	    public object Map(Type sourceType, Type destinationType, object source)
	    {
            return _mappingEngine.Map(source, sourceType, destinationType);
	    }

	    /// <summary>
		/// Maps the source object to the specified destination type.
		/// </summary>
		/// <typeparam name="TSource"></typeparam>
		/// <typeparam name="TDestination"></typeparam>
		/// <typeparam name="TChainDestination"></typeparam>
		/// <param name="source"></param>
		/// <returns></returns>
		public TChainDestination Map<TSource, TDestination, TChainDestination>(TSource source)
		{
            TDestination destination = _mappingEngine.Map<TSource, TDestination>(source);
            return _mappingEngine.Map<TDestination, TChainDestination>(destination);
		}
	}
}
