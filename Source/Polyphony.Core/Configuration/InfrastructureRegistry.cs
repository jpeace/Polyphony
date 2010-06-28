using AutoMapper;
using Polyphony.Core.Infrastructure;
using Polyphony.Infrastructure;
using StructureMap.Configuration.DSL;

namespace Polyphony.Core.Configuration
{
	/// <summary>
	/// Provides a common registry mechanism for the infrastructure layer.
	/// </summary>
	public class InfrastructureRegistry : Registry
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="InfrastructureRegistry"/> class.
		/// </summary>
        public InfrastructureRegistry()
		{
		    For<IMappingEngine>().Use(() => Mapper.Engine);
		    For<IMappingRegistry>().Use<AutoMapperMappingRegistry>();
		}
	}
}
