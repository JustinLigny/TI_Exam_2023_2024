using Application.Features.Invitation.Dtos;
using Application.Shared.Exceptions.Exceptions;
using AutoMapper;
using Infrastructure.Entities;
using Infrastructure.Repositories;

namespace Application.Features.Invitation;

public class InvitationService
{
    private readonly IInvitationRepository _invitationRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public InvitationService(IInvitationRepository invitationRepository, IUserRepository userRepository, IMapper mapper)
    {
        _invitationRepository = invitationRepository;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public InvitationResponseDto Create(InvitationCreateDto invitationCreateDto)
    {
        if (_userRepository.GetById(invitationCreateDto.UserSenderId) == null)
            throw new EntityDoesNotExistsException("The sender user does not exist");
        
        if (_userRepository.GetById(invitationCreateDto.UserInvitedId) == null)
            throw new EntityDoesNotExistsException("This invited user does not exist");

        if (_invitationRepository.ExistsByUserSenderIdAndUserInvitedId(
                invitationCreateDto.UserSenderId, invitationCreateDto.UserInvitedId))
            throw new EntityAlreadyExistsException("You have already invited this user");
        
        var invitationDomain = _mapper.Map<Domain.Invitation>(invitationCreateDto);
        var publicationDb = _mapper.Map<DbInvitation>(invitationDomain);
        var publicationDbCreated = _invitationRepository.Create(publicationDb);
        return _mapper.Map<InvitationResponseDto>(publicationDbCreated);
    }

    public List<InvitationResponseDto> GetInvitationsAsSender(int userSenderId)
    {
        var invitations = _invitationRepository.GetInvitationsBySenderId(userSenderId);
        return _mapper.Map<List<InvitationResponseDto>>(invitations);
    }

    public List<InvitationResponseDto> GetInvitationsAsInvited(int userInvitedId)
    {
        var invitations = _invitationRepository.GetInvitationsByInvitedId(userInvitedId);
        return _mapper.Map<List<InvitationResponseDto>>(invitations);
    }
    
}