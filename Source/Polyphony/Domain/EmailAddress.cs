namespace Polyphony.Domain
{
    /// <summary>
    /// Represents a email address.
    /// </summary>
    public class EmailAddress : ContactMethod
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmailAddress"/> class.
        /// </summary>
        protected EmailAddress()
        {
            ContactMethodType = ContactMethodType.Email;
        }
        /// <summary>
        /// Gets or sets one of the <see cref="Domain.EmailType"/> values indicating the type of email address.
        /// </summary>
        public virtual EmailType EmailType { get; set; }
    }
}