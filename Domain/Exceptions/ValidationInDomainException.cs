namespace Domain.Exceptions;

public class ValidationInDomainException: Exception
{
    public readonly string Attribute;
    public ValidationInDomainException(string attribute, string? message) : base(message)
    {
        Attribute = attribute;
    }
}