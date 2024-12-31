using Infrastructure.Entities;

namespace Infrastructure.Repositories;

public class UserRepository: IUserRepository
{
    
    private readonly DatabaseContext _context;

    public UserRepository(DatabaseContext context)
    {
        _context = context;
    }

    public DbUser Create(DbUser user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
        return user.Clone();
    }
    
    public List<DbUser> GetAll()
    {
        return _context.Users.ToList();
    }

    public DbUser? GetById(int id)
    {
        return _context.Users.FirstOrDefault(u => u.Id == id);
    }

    public DbUser? GetByPseudo(string pseudo)
    {
        return _context.Users.FirstOrDefault(u => u.Pseudo == pseudo);
    }

    public bool ExistsByPseudo(string pseudo)
    {
        return _context.Users.Any(u => u.Pseudo == pseudo);
    }
}