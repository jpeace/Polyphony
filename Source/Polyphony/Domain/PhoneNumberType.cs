namespace Polyphony.Domain
{
    /// <summary>
    /// Defines the permissable values for indicating the type of a phone number (e.g., 'Home').
    /// </summary>
    public enum PhoneNumberType
    {
        /// <summary>
        /// Specifies that the phone number is a home number.
        /// </summary>
        Home = 1,
        /// <summary>
        /// Specifies that the phone number is an office number.
        /// </summary>
        Office = 2,
        /// <summary>
        /// Specifies that the phone number is a mobile number.
        /// </summary>
        Mobile = 3
    }
}