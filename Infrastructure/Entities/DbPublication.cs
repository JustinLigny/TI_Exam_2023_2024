namespace Infrastructure.Entities;

public class DbPublication
{
    public int Id { get; set; }
    public int CreatedByUserId { get; set; } 
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }
    
    public DbUser CreatedByUser { get; set; }

    public DbPublication Clone()
    {
        return (DbPublication)MemberwiseClone();
    }
}