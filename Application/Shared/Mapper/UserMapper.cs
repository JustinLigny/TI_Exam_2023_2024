using Application.Core.User.Dtos;
using AutoMapper;
using Domain;
using Infrastructure.Entities;

namespace Application.Shared.Mapper;

public class UserMapper: Profile
{
    public UserMapper()
    {
        CreateMap<UserCreateDTO, User>();
        CreateMap<User, DbUser>().ReverseMap();
        CreateMap<DbUser, UserResponseDTO>();
    }
}