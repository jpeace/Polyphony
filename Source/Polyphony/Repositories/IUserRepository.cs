using System.Collections.Generic;
using Polyphony.Domain;

namespace Polyphony.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
    }
}