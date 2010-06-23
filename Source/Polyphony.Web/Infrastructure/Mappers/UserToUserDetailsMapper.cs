using AutoMapper;
using Polyphony.Core.Infrastructure;
using Polyphony.Domain;
using Polyphony.Web.Models.Users;

namespace Polyphony.Web.Infrastructure.Mappers
{
    public class UserToUserDetailsMapper : IMapper
    {
        /// <summary>
        /// Creates the appropriate map.
        /// </summary>
        /// <param name="configuration">The configuration context.</param>
        public void CreateMap(IConfiguration configuration)
        {
            configuration.CreateMap<User, UserDetailsModel>();
        }
    }
}