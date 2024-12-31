using System.Text.Json.Serialization;

namespace Application.Core.User.Dtos;

public class UserCreateDTO
{
    public string Pseudo { get; set; }
    [JsonIgnore] public string Role { get; set; } = "USER";
}