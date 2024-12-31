namespace Application.Shared.Exceptions.Exceptions;

public class RequestCannotBePerformedException: Exception
{
    public RequestCannotBePerformedException(string? message) : base(message)
    {
    }
}