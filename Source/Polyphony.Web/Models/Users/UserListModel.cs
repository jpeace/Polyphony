using System.Collections.Generic;

namespace Polyphony.Web.Models.Users
{
    public class UserListModel
    {
        public IEnumerable<UserDetailsModel> Users { get; set; }
    }
}