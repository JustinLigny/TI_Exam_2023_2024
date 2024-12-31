using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class InvitationRepository: IInvitationRepository
{
    private readonly DatabaseContext _context;

    public InvitationRepository(DatabaseContext context)
    {
        _context = context;
    }
    
    public DbInvitation Create(DbInvitation invitation)
    {
        _context.Invitations.Add(invitation);
        _context.SaveChanges();
        return invitation.Clone();
    }

    public bool ExistsByUserSenderIdAndUserInvitedId(int userSenderId, int userInvitedId)
    {
        return _context.Invitations.Any(
            i => i.UserInvitedId == userInvitedId && 
                 i.UserSenderId == userSenderId);
    }

    public List<DbInvitation> GetInvitationsBySenderId(int userSenderId)
    {
        return _context.Invitations.
            Where(i => i.UserSenderId == userSenderId)
            .Include(i => i.UserSender)
            .Include(i => i.UserInvited)
            .ToList();
    }

    public List<DbInvitation> GetInvitationsByInvitedId(int userInvitedId)
    {
        return _context.Invitations
            .Where(i => i.UserInvitedId == userInvitedId)
            .Include(i => i.UserSender)
            .Include(i => i.UserInvited)
            .ToList();
    }
}