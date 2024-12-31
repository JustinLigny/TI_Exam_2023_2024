namespace Application.Shared.Exceptions.Exceptions;

public class EntityAlreadyAssignedException: Exception
{
    public EntityAlreadyAssignedException(string? message) : base(message)
    {
    }
}