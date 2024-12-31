using Domain.Exceptions;

namespace Domain;

public class Publication
{
    private int _id;
    private int _createdByUserId;
    private string _title;
    private string _content;
    private DateTime _createdAt;
    
    public User CreatedByUser { get; set; }

    public int Id
    {
        get => _id;
        set { _id = value; }
    }

    public int CreatedByUserId
    {
        get => _createdByUserId;
        set
        {
            if (value <= 0)
                throw new ValidationInDomainException(nameof(CreatedByUserId),
                    "CreatedByUserId must be a positive integer.");
            _createdByUserId = value;
        }
    }

    public string Title
    {
        get => _title;
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new ValidationInDomainException(nameof(Title), "Title cannot be empty.");
            if (value.Length > 30)
                throw new ValidationInDomainException(nameof(Title), "Title cannot be longer than 30 characters.");
            _title = value;
        }
    }

    public string Content
    {
        get => _content;
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new ValidationInDomainException(nameof(Content), "Content cannot be empty.");
            if (value.Length > 200)
                throw new ValidationInDomainException(nameof(Content), "Content cannot be longer than 200 characters.");
            _content = value;
        }
    }

    public DateTime CreatedAt
    {
        get => _createdAt;
        set
        {
            if (value > DateTime.Now.AddMinutes(1))
                throw new ValidationInDomainException(nameof(CreatedAt), "CreatedAt cannot be in the future.");
            _createdAt = value;
        }
    }
}
