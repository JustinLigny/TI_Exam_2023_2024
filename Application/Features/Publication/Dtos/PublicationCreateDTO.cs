using System.Text.Json.Serialization;

namespace Application.Features.Publication.Dtos;

public class PublicationCreateDto
{
    public string Title { get; set; }
    public string Content { get; set; }
    [JsonIgnore] public DateTime CreatedAt { get; set; } = DateTime.Now;
    [JsonIgnore] public int CreatedByUserId { get; set; }
}