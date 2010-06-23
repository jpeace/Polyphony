using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoMapper;
using Microsoft.Practices.ServiceLocation;

namespace Polyphony.Core.Infrastructure
{
	/// <summary>
	/// Provides an orchestration mechanism for automatically triggering mappers for the AutoMapper framework.
	/// </summary>
	public static class AutoMapperExtensions
	{
        /// <summary>
        /// Creates the specified mapper.
        /// </summary>
        /// <param name="configuration">The configuration context.</param>
        /// <typeparam name="TMap">Type of mapper.</typeparam>
        public static void IncludeMap<TMap>(this IConfiguration configuration)
            where TMap : IMapper
        {
            var mapper = ServiceLocator.Current.GetInstance<TMap>();
            mapper.CreateMap(configuration);
        }
		/// <summary>
		/// Creates all maps in the assembly in which the specified mapper type is declared.
		/// </summary>
		/// <param name="configuration">The configuration context.</param>
		/// <typeparam name="TMap">Type of mapper.</typeparam>
		public static void AddAllFromAssemblyContainingType<TMap>(this IConfiguration configuration)
			where TMap : IMapper
		{
			var mappers = FindMapsFromAssembly(typeof(TMap).Assembly);
			foreach (var mapper in mappers)
			{
				mapper.CreateMap(configuration);
			}
		}
		/// <summary>
		/// Finds all maps from the specified assembly.
		/// </summary>
		/// <param name="assembly">The assembly to load from.</param>
		/// <returns></returns>
		private static IEnumerable<IMapper> FindMapsFromAssembly(Assembly assembly)
		{
			Type mapType = typeof(IMapper);
			Type[] types;
			try
			{
				types = assembly.GetExportedTypes();
			}
			catch(NotSupportedException) // Dynamic assemblies
			{
				yield break;	
			}

			foreach (Type type in types.Where(t => mapType.IsAssignableFrom(t) && !t.IsAbstract && !t.IsInterface))
			{
                yield return (IMapper)ServiceLocator.Current.GetInstance(type);
			}
		}
	}
}