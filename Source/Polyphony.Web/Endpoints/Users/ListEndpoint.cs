using System.Linq;
using Polyphony.Domain;
using Polyphony.Infrastructure;
using Polyphony.Repositories;
using Polyphony.Web.Models.Users;

namespace Polyphony.Web.Endpoints.Users
{
    public class ListEndpoint
    {
        private readonly IMappingRegistry _mappingRegistry;
        private readonly IUserRepository _userRepository;

        public ListEndpoint(IMappingRegistry mappingRegistry, IUserRepository userRepository)
        {
            _mappingRegistry = mappingRegistry;
            _userRepository = userRepository;
        }

        public UserListModel Get()
        {
            var users = from u in _userRepository.GetAll()
                        select _mappingRegistry.Map<User, UserDetailsModel>(u);

            return new UserListModel
                       {
                           Users = users
                       };
        }
    }
}