using Application.Core.User.Dtos;
using Application.Core.User;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.User;

[ApiController]
[Route("api/users")]
public class UserController
{
    private readonly UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public UserResponseDTO Create([FromBody] UserCreateDTO user)
    {
        return _userService.Create(user);
    }
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public List<UserResponseDTO> GetUsers()
    {
        return _userService.GetAll();
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public UserResponseDTO GetUser(int id)
    {
        return _userService.GetById(id);
    }
    
}