using AutoMapper;

namespace Polyphony.Core.Infrastructure
{
	/// <summary>
	/// Provides a contract for registries to implement to automatically be invoked.
	/// </summary>
	public interface IMapper
	{
		/// <summary>
		/// Creates the appropriate map.
		/// </summary>
		/// <param name="configuration">The configuration context.</param>
		void CreateMap(IConfiguration configuration);
	}
}