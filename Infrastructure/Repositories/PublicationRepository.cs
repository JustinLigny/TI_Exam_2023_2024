using Infrastructure.Entities;

namespace Infrastructure.Repositories;

public class PublicationRepository: IPublicationRepository
{
    
    private readonly DatabaseContext _context;

    public PublicationRepository(DatabaseContext context)
    {
        _context = context;
    }
    
    public DbPublication Create(DbPublication publication)
    {
        _context.Publications.Add(publication);
        _context.SaveChanges();
        return publication.Clone();
    }

    public List<DbPublication> GetAllFromFriends(int userId)
    {
        // TODO CHanger par celle des amis
        return _context.Publications.ToList();
    }
}