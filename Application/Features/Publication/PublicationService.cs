using Application.Features.Publication.Dtos;
using Application.Shared.Exceptions.Exceptions;
using AutoMapper;
using Infrastructure.Entities;
using Infrastructure.Repositories;

namespace Application.Features.Publication;

public class PublicationService
{
    private readonly IPublicationRepository _publicationRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public PublicationService(IPublicationRepository publicationRepository, IUserRepository userRepository, IMapper mapper)
    {
        _publicationRepository = publicationRepository;
        _userRepository = userRepository;
        _mapper = mapper;
    }
    
    public PublicationResponseDto Create(PublicationCreateDto publicationDto)
    {
        if (_userRepository.GetById(publicationDto.CreatedByUserId) == null)
            throw new EntityDoesNotExistsException("This user does not exist");
        
        var publicationDomain = _mapper.Map<Domain.Publication>(publicationDto);
        var publicationDb = _mapper.Map<DbPublication>(publicationDomain);
        var publicationDbCreated = _publicationRepository.Create(publicationDb);
        return _mapper.Map<PublicationResponseDto>(publicationDbCreated);
    }
    
    public List<PublicationResponseDto> GetAllFromFriends(int userId)
    {
        var publications = _publicationRepository.GetAllFromFriends(userId);
        return _mapper.Map<List<PublicationResponseDto>>(publications);
    }
}