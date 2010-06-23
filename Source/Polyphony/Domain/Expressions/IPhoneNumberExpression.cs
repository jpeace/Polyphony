namespace Polyphony.Domain.Expressions
{
    public interface IPhoneNumberExpression
    {
        IPhoneNumberExpression WithValue(string phoneNumberValue);
        IPhoneNumberExpression WithType(PhoneNumberType phoneNumberType);
    }
}