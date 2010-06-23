using System.Collections.Generic;
using Polyphony.Domain;

namespace Polyphony.Web.Models.Users
{
    public class UserDetailsModel
    {
        /// <summary>
        /// Gets or sets the unique identifier of the user.
        /// </summary>
        public virtual int UserId { get; private set; }
        /// <summary>
        /// Gets or sets the first name of the user.
        /// </summary>
        public virtual string FirstName { get; set; }
        /// <summary>
        /// Gets or sets the last name of the user.
        /// </summary>
        public virtual string LastName { get; set; }
        /// <summary>
        /// Gets or sets the associated collection of phone numbers.
        /// </summary>
        public virtual IEnumerable<PhoneNumber> PhoneNumbers { get; set; }
        /// <summary>
        /// Gets or sets the associated collection of email addresses.
        /// </summary>
        public virtual IEnumerable<EmailAddress> EmailAddresses { get; set; }
    }
}