using BookStore.CoreDomain.Abstractions;
using BookStore.CoreDomain.Enums;
using BookStore.CoreDomain.Models;
using BookStore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.DataAccess.Repositories;

public class UsersRepository : IUsersRepository
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

    public async Task AddQuick(User user)
    {
        var roleEntity = await _context.Roles
            .SingleOrDefaultAsync(r => r.Id == (int)Role.User)
            ?? throw new InvalidOperationException();

        var userEntity = new UserEntity()
        { Id = user.Id, UserName = user.UserName, PasswordHash = user.PasswordHash, Email=user.Email, Roles = [roleEntity] };

        await _context.Users.AddAsync(userEntity);
        await _context.SaveChangesAsync();
    }

    public async Task<User> GetByEmail(string email)
    {
        var userEntity = await _context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Email == email) ?? throw new Exception();

        //TODO : ИСПОЛЬЗОВАТЬ IMapper из AutoMapper вместо ручного
        //TODO : Валидация юзера

        var user = User.Create(userEntity.Id, userEntity.UserName, userEntity.PasswordHash, userEntity.Email);
        return user;
    }

    public async Task<HashSet<Permission>> GetUserPermissions (Guid userId)
    {
        var roles = await _context.Users
            .AsNoTracking()
            .Include(u => u.Roles)
            .ThenInclude(r => r.Permissions)
            .Where(u => u.Id == userId)
            .Select(u => u.Roles)
            .ToArrayAsync();

        return roles
            .SelectMany(r => r)
            .SelectMany(r => r.Permissions)
            .Select(p => (Permission)p.Id)
            .ToHashSet();
    }
}
