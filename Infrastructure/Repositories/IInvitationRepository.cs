﻿using Infrastructure.Entities;

namespace Infrastructure.Repositories;

public interface IInvitationRepository
{
    DbInvitation Create(DbInvitation invitation);
    DbInvitation? GetById(int invitationId);
    DbInvitation Update(DbInvitation invitation);
    Boolean ExistsByUserSenderIdAndUserInvitedId(int userSenderId, int userInvitedId);
    List<DbInvitation> GetInvitationsBySenderId(int userSenderId);
    List<DbInvitation> GetInvitationsByInvitedId(int userInvitedId);
}