namespace Application.Shared.Exceptions.Exceptions;

public class EntityDoesNotExistsException: Exception
{
    public EntityDoesNotExistsException(string? message) : base(message)
    {
    }
}