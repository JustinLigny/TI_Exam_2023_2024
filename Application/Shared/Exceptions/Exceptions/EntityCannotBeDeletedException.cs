namespace Application.Shared.Exceptions.Exceptions;

public class EntityCannotBeDeletedException: Exception
{
    public EntityCannotBeDeletedException(string? message) : base(message)
    {
    }
}