namespace Infrastructure.Entities;

public class DbUser
{
    public int Id { get; set; }
    public string Pseudo { get; set; }
    public string Role { get; set; }
    
    public ICollection<DbPublication> Publications { get; set; } = new List<DbPublication>();

    public DbUser Clone()
    {
        return (DbUser)MemberwiseClone();
    }
}