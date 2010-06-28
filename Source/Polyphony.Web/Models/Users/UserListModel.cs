using System.Collections.Generic;

namespace Polyphony.Web.Models.Users
{
    public class UserListModel
    {
        public string Test
        {
            get
            {
                return "Testing...";
            }
        }
        public IEnumerable<UserDetailsModel> Users { get; set; }
    }
}