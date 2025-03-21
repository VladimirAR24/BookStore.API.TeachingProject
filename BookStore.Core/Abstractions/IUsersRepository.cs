using BookStore.CoreDomain.Models;

namespace BookStore.CoreDomain.Abstractions;

public interface IUsersRepository
{
    Task<Guid> Add(User user);
    Task<List<User>> GetAll();
    Task<User> GetByEmail(string email);
}