namespace Polyphony.Domain
{
    /// <summary>
    /// Represents a phone number.
    /// </summary>
    public class PhoneNumber : ContactMethod
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PhoneNumber"/> class.
        /// </summary>
        protected PhoneNumber()
        {
            ContactMethodType = ContactMethodType.Phone;
        }
        /// <summary>
        /// Gets or sets one of the <see cref="Domain.PhoneNumberType"/> values indicating the type of phone number.
        /// </summary>
        public virtual PhoneNumberType PhoneNumberType { get; private set; }
    }
}