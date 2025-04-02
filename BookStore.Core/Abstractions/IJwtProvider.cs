using BookStore.CoreDomain.Models;

namespace BookStore.CoreDomain.Abstractions;

public interface IJwtProvider
{
    string GenerateToken(User user);
}