using Application.Core.User.Dtos;

namespace Application.Features.Invitation.Dtos;

public class InvitationResponseDto
{
    public int Id { get; set; }
    public string Status { get; set; }
    public UserResponseDTO UserSender { get; set; }
    public UserResponseDTO UserInvited { get; set; }
}