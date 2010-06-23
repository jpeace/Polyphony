namespace Polyphony.Domain
{
    /// <summary>
    /// Defines the permissable values for indicating the type of an email address (e.g., 'Home').
    /// </summary>
    public enum EmailType
    {
        /// <summary>
        /// Specifies that the email address is a home address.
        /// </summary>
        Home = 1,
        /// <summary>
        /// Specifies that the email address is an office address.
        /// </summary>
        Office = 2
    }
}