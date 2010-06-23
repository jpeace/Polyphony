namespace Polyphony.Domain
{
    /// <summary>
    /// Represents a method for which a user can be contacted.
    /// </summary>
    public abstract class ContactMethod
    {
        /// <summary>
        /// Gets or sets unique identifier of the contact method.
        /// </summary>
        public virtual int ContactMethodId { get; set; }
        /// <summary>
        /// Gets or sets one of the <see cref="ContactMethodType"/> values indicating the type of contact method.
        /// </summary>
        public virtual ContactMethodType ContactMethodType { get; protected set; }
        /// <summary>
        /// Gets or sets the value of the email address.
        /// </summary>
        public virtual string Value { get; set; }
        /// <summary>
        /// Gets or sets the user for which the contact method is for.
        /// </summary>
        public virtual User User { get; protected set; }
    }

    public enum ContactMethodType
    {
        Email = 1,
        Phone = 2
    }
}