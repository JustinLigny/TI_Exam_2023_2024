using Infrastructure.Entities;

namespace Infrastructure.Repositories;

public interface IUserRepository
{
    DbUser Create(DbUser user);
    
    List<DbUser> GetAll();
    DbUser? GetById(int id);
    DbUser? GetByPseudo(String pseudo);
    Boolean ExistsByPseudo(String pseudo);
}