using Application.Features.Invitation;
using Application.Features.Invitation.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.InvitationController;

[ApiController]
[Route("api")]
public class InvitationController
{
    private readonly InvitationService _invitationService;

    public InvitationController(InvitationService invitationService)
    {
        _invitationService = invitationService;
    }

    [HttpPost("users/{userSenderId}/invitations")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public InvitationResponseDto Create(int userSenderId, [FromBody] InvitationCreateDto invitationCreateDto)
    {
        invitationCreateDto.UserSenderId = userSenderId;
        return _invitationService.Create(invitationCreateDto);
    }

    [HttpGet("users/{userSenderId}/invitations/sent")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public List<InvitationResponseDto> GetInvitationAsSender(int userSenderId)
    {
        return _invitationService.GetInvitationsAsSender(userSenderId);
    }

    [HttpGet("users/{userInvitedId}/invitations/received")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public List<InvitationResponseDto> GetInvitationAsInvited(int userInvitedId)
    {
        return _invitationService.GetInvitationsAsInvited(userInvitedId);
    }
}