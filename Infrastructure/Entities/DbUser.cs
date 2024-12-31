namespace Infrastructure.Entities;

public class DbUser
{
    public int Id { get; set; }
    public string Pseudo { get; set; }
    public string Role { get; set; }
    
    public ICollection<DbPublication> Publications { get; set; } = new List<DbPublication>();
    public ICollection<DbInvitation> InvitationsAsSender { get; set; } = new List<DbInvitation>();
    public ICollection<DbInvitation> InvitationsAsInvited { get; set; } = new List<DbInvitation>();

    public DbUser Clone()
    {
        return (DbUser)MemberwiseClone();
    }
}