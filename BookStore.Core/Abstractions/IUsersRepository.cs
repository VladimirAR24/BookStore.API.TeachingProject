using BookStore.CoreDomain.Enums;
using BookStore.CoreDomain.Models;

namespace BookStore.CoreDomain.Abstractions;

public interface IUsersRepository
{
    Task<Guid> Add(User user);
    Task AddQuick(User user);
    Task<List<User>> GetAll();
    Task<User> GetByEmail(string email);
    Task<HashSet<Permission>> GetUserPermissions(Guid userId);
}