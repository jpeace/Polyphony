using System;
using System.Collections.Generic;
using Polyphony.Domain.Builders;
using Polyphony.Domain.Expressions;

namespace Polyphony.Domain
{
    /// <summary>
    /// Represents a user within the system.
    /// </summary>
    public class User
    {
        private readonly IList<PhoneNumber> _phoneNumbers;
        private readonly IList<EmailAddress> _emailAddresses;
        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        public User()
        {
            _phoneNumbers = new List<PhoneNumber>();
            _emailAddresses = new List<EmailAddress>();
        }
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
        /// Gets the associated collection of phone numbers.
        /// </summary>
        public virtual IEnumerable<PhoneNumber> PhoneNumbers { get { return _phoneNumbers; } }
        /// <summary>
        /// Gets the associated collection of email addresses.
        /// </summary>
        public virtual IEnumerable<EmailAddress> EmailAddresses { get { return _emailAddresses; } }
        /// <summary>
        /// Adds a new phone number.
        /// </summary>
        /// <param name="expression">Phone number expression to construct a new phone number.</param>
        public virtual void AddPhoneNumber(Action<IPhoneNumberExpression> expression)
        {
            var builder = new PhoneNumberBuilder(this);
            expression(builder);
            _phoneNumbers.Add(builder.Build());
        }
        /// <summary>
        /// Adds a new phone number.
        /// </summary>
        /// <param name="expression">Phone number expression to construct a new phone number.</param>
        public virtual void AddEmailAddress(Action<IEmailAddressExpression> expression)
        {
            var builder = new EmailAddressBuilder(this);
            expression(builder);
            _emailAddresses.Add(builder.Build());
        }
    }
}