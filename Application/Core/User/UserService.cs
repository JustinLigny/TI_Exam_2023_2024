using Application.Core.User.Dtos;
using Application.Shared.Exceptions.Exceptions;
using AutoMapper;
using Infrastructure.Entities;
using Infrastructure.Repositories;

namespace Application.Core.User;

public class UserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public UserResponseDTO Create(UserCreateDTO userDto)
    {
        var userDomain = _mapper.Map<Domain.User>(userDto);

        if (_userRepository.ExistsByPseudo(userDomain.Pseudo))
            throw new EntityAlreadyExistsException("Pseudo already exists");
        
        var userDb = _mapper.Map<DbUser>(userDomain);
        var userDbCreated = _userRepository.Create(userDb);
        return _mapper.Map<UserResponseDTO>(userDbCreated);
    }
    
    public List<UserResponseDTO> GetAll()
    {
        var users = _userRepository.GetAll();
        return _mapper.Map<List<UserResponseDTO>>(users);
    }

    public UserResponseDTO GetById(int id)
    {
        var optionalUser = _userRepository.GetById(id);
        if(optionalUser == null)
            throw new EntityDoesNotExistsException("User not found with this ID");

        return _mapper.Map<UserResponseDTO>(optionalUser);
    }
    
    public DbUser GetByPseudo(string pseudo)
    {
        var optionalUser = _userRepository.GetByPseudo(pseudo);
        if(optionalUser == null)
            throw new EntityDoesNotExistsException("User not found with this PSEUDO");

        return optionalUser;
    }
    
}