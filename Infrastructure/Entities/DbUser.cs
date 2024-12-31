namespace Infrastructure.Entities;

public class DbUser
{
    public int Id { get; set; }
    public string Pseudo { get; set; }
    public string Role { get; set; }

    public DbUser Clone()
    {
        return (DbUser)MemberwiseClone();
    }
}