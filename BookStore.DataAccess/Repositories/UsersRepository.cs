using BookStore.CoreDomain.Models;
using BookStore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.DataAccess.Repositories;

public class UsersRepository
{
    private readonly BookStoreDbContext _context;

    public UsersRepository(BookStoreDbContext context)
    {
        _context = context;
    }

    public async Task<List<User>> GetAll()
    {
        var userEntity = await _context.Users
            .AsNoTracking()
            .ToListAsync();

        var users = userEntity
            .Select(u => User.Create(u.Id, u.UserName, u.PasswordHash, u.Email))
            .ToList();

        return users;
    }

    public async Task<Guid> Add(User user)
    {
        var userEntity = new UserEntity
        { Id = user.Id, UserName = user.UserName, PasswordHash = user.PasswordHash, Email = user.Email };

        await _context.Users.AddAsync(userEntity);
        await _context.SaveChangesAsync();
        return userEntity.Id;
    }

    public async Task<User> GetByEmail(string email)
    {
        var userEntity = await _context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Email == email);

        //TODO : ИСПОЛЬЗОВАТЬ IMapper из AutoMapper вместо ручного
        //TODO : Валидация юзера

        var user = User.Create(userEntity.Id, userEntity.UserName, userEntity.PasswordHash, userEntity.Email);
        return user;
    }
}
