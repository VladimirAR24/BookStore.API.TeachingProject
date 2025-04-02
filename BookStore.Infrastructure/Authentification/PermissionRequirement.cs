using BookStore.CoreDomain.Enums;
using Microsoft.AspNetCore.Authorization;

namespace BookStore.Infrastructure.Authentification;

public class PermissionRequirement : IAuthorizationRequirement
{
    public PermissionRequirement(Permission[] permissions)
    {
        Permissions = permissions;
    }
    public Permission[] Permissions { get; set; } = [];

}
