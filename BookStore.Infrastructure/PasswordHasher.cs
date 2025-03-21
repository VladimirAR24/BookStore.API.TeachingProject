using BookStore.CoreDomain.Abstractions;

namespace BookStore.Infrastructure;

public class PasswordHasher : IPasswordHasher
{
    public string Generate(string password) =>
        BCrypt.Net.BCrypt.EnhancedHashPassword(password);

    public bool Verify(string passwrod, string hashedPassword) =>
        BCrypt.Net.BCrypt.EnhancedVerify(passwrod, hashedPassword);
}
