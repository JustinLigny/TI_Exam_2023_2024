using Application.Core.User.Dtos;
using Application.Features.Invitation.Dtos;
using Application.Features.Publication.Dtos;
using AutoMapper;
using Domain;
using Infrastructure.Entities;

namespace Application.Shared.Mapper;

public class Mapper: Profile
{
    public Mapper()
    {
        CreateMap<UserCreateDTO, User>();
        CreateMap<User, DbUser>().ReverseMap();
        CreateMap<DbUser, UserResponseDTO>();
        
        CreateMap<PublicationCreateDto, Publication>();
        CreateMap<Publication, DbPublication>().ReverseMap();
        CreateMap<DbPublication, PublicationResponseDto>();
        
        CreateMap<InvitationCreateDto, Invitation>();
        CreateMap<Invitation, DbInvitation>().ReverseMap();
        CreateMap<DbInvitation, InvitationResponseDto>();
        
    }
}