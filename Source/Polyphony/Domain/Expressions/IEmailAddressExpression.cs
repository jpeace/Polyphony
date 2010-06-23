namespace Polyphony.Domain.Expressions
{
    public interface IEmailAddressExpression
    {
        IEmailAddressExpression WithValue(string emailAddressValue);
        IEmailAddressExpression WithType(EmailType emailType);
    }
}