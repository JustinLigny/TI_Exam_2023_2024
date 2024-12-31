using System.Text.Json.Serialization;

namespace Application.Features.Invitation.Dtos;

public class InvitationCreateDto
{
    [JsonIgnore] public string Status { get; set; } = "PENDING";
    [JsonIgnore] public int UserSenderId { get; set; }
    public int UserInvitedId { get; set; }
}