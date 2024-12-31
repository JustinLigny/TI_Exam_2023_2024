using Infrastructure.Entities;

namespace Infrastructure.Repositories;

public interface IPublicationRepository
{
    DbPublication Create(DbPublication publication);
    List<DbPublication> GetAllFromFriends(int userId);
}