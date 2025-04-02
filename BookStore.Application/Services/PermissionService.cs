using BookStore.CoreDomain.Abstractions;
using BookStore.CoreDomain.Enums;

namespace BookStore.Application.Services;

public class PermissionService : IPermissionService
{
    private readonly IUsersRepository _usersRepository;

    public PermissionService(IUsersRepository usersRepository)
    {
        _usersRepository = usersRepository;
    }

    public Task<HashSet<Permission>> GetPermissionsAsync(Guid userId)
    {
        return _usersRepository.GetUserPermissions(userId);
    }
}
