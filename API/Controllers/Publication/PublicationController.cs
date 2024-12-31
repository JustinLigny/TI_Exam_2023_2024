using Application.Features.Publication;
using Application.Features.Publication.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Publication;

[ApiController]
[Route("api")]
public class PublicationController
{
    private readonly PublicationService _publicationService;

    public PublicationController(PublicationService publicationService)
    {
        _publicationService = publicationService;
    }

    [HttpPost("/users/{userId}/publications")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public PublicationResponseDto Create(int userId, [FromBody] PublicationCreateDto publicationCreateDto)
    {
        publicationCreateDto.CreatedByUserId = userId;
        return _publicationService.Create(publicationCreateDto);
    }
    
    [HttpGet("/users/{userId}/publications")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public List<PublicationResponseDto> GetAllFromFriends(int userId)
    {
        return _publicationService.GetAllFromFriends(userId);
    }
}