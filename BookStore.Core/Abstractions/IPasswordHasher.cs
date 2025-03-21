namespace BookStore.CoreDomain.Abstractions
{
    public interface IPasswordHasher
    {
        string Generate(string password);

        bool Verify(string passwrod, string hashedPassword);
    }
}