namespace Infrastructure.Entities;

public class DbInvitation
{
    public int Id;
    public int UserSenderId;
    public int UserInvitedId;
    public string Status;

    public DbUser UserSender { get; set; }
    public DbUser UserInvited { get; set; }

    public DbInvitation Clone()
    {
        return (DbInvitation)MemberwiseClone();
    }
}