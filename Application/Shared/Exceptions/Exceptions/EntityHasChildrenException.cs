namespace Application.Shared.Exceptions.Exceptions;

public class EntityHasChildrenException: Exception
{
    public EntityHasChildrenException(string? message) : base(message)
    {
    }
}