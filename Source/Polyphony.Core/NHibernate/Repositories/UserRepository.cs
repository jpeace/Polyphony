using System;
using System.Collections.Generic;
using NHibernate;
using Polyphony.Domain;
using Polyphony.Repositories;

namespace Polyphony.Core.NHibernate.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ISession _session;

        public UserRepository(ISession session)
        {
            _session = session;
        }

        public IEnumerable<User> GetAll()
        {
            return _session
                .CreateCriteria<User>()
                .SetFetchMode("EmailAddresses", FetchMode.Eager)
                .SetFetchMode("PhoneNumbers", FetchMode.Eager)
                .List<User>();
        }
    }
}