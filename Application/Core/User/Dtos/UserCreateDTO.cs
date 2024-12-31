namespace Application.Core.User.Dtos;

public class UserCreateDTO
{
    public string Pseudo { get; set; }
    public string Role { get; set; } = "USER";
}