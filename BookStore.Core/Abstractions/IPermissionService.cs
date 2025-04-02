using BookStore.CoreDomain.Enums;

namespace BookStore.CoreDomain.Abstractions;

public interface IPermissionService
{
    Task<HashSet<Permission>> GetPermissionsAsync(Guid userId);
}