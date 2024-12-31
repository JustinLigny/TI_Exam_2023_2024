using Application.Core.User.Dtos;

namespace Application.Features.Publication.Dtos;

public class PublicationResponseDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }
    public UserResponseDTO CreatedByUser { get; set; }
}