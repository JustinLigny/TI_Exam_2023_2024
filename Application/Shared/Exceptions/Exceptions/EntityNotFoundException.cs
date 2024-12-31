namespace Application.Shared.Exceptions.Exceptions;

public class EntityNotFoundException: Exception
{
    public EntityNotFoundException(string? message) : base(message)
    {
    }
}