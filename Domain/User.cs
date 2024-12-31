using Domain.Exceptions;

namespace Domain;

public class User
{
    private int _id;
    private string _pseudo;
    private string _role;

    public ICollection<Publication> Publications { get; set; } = new List<Publication>();
    public ICollection<Invitation> InvitationsAsSender { get; set; } = new List<Invitation>();
    public ICollection<Invitation> InvitationsAsInvited { get; set; } = new List<Invitation>();
 
    public int Id
    {
        get => _id;
        set { _id = value; }
    }

    public string Pseudo
    {
        get => _pseudo;
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new ValidationInDomainException(nameof(Pseudo),
                    "Pseudo cannot be empty");
            if (value.Length > 50)
                throw new ValidationInDomainException(nameof(Pseudo),
                    "Pseudo cannot be longer than 50 characters");
            _pseudo = value;
        }
    }
    
    public string Role
    {
        get => _role;
        set
        {
            value = value.ToUpper();
            if (string.IsNullOrWhiteSpace(value))
                throw new ValidationInDomainException(nameof(Role), "Role cannot be null or empty.");
            if (value != "USER" && value != "ADMIN")
                throw new ValidationInDomainException(nameof(Role), "Role must be a valid role name (user, admin).");
            _role = value;
        }
    }
}