using Domain.Exceptions;

namespace Domain;

public class Invitation
{
    private int _id;
    private int _userSenderId;
    private int _userInvitedId;
    private string _status;

    public User UserSender { get; set; }
    public User UserInvited { get; set; }
    
    public int Id
    {
        get => _id;
        set { _id = value; }
    }

    public int UserSenderId
    {
        get => _userSenderId;
        set
        {
            if (value <= 0)
                throw new ValidationInDomainException(nameof(UserSenderId),
                    "UserSenderId must be a positive integer.");
            _userSenderId = value;
        }
    }

    public int UserInvitedId
    {
        get => _userInvitedId;
        set
        {
            if (value <= 0)
                throw new ValidationInDomainException(nameof(UserInvitedId),
                    "UserInvitedId must be a positive integer.");
            _userInvitedId = value;
        }
    }

    public string Status
    {
        get => _status;
        set
        {
            value = value.ToUpper();
            if (string.IsNullOrWhiteSpace(value))
                throw new ValidationInDomainException(nameof(Status), "Status cannot be null or empty.");
            if (value != "PENDING" && value != "ACCEPTED" && value != "REJECTED")
                throw new ValidationInDomainException(nameof(Status), "Status must be one of 'PENDING', 'ACCEPTED', or 'REJECTED'.");
            _status = value;
        }
    }
}