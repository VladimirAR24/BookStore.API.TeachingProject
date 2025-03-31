using BookStore.CoreDomain.Enums;
using BookStore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Net;

namespace BookStore.DataAccess.Configurations;

public class RolePermissionConfigurations() : IEntityTypeConfiguration<RolePermissionEntity>
{

    public void Configure(EntityTypeBuilder<RolePermissionEntity> builder)
    {
        builder.HasKey(r => new { r.RoleId, r.PermissionId });

        var rolePermitions = ParseRolePermissions();

        builder.HasData(rolePermitions);
    }

    private List<RolePermissionEntity> ParseRolePermissions()
    {
        var authorizationOptions = new AuthorizationOptions();
        return authorizationOptions.RolePermissions
            .SelectMany(rp => rp.Permissions
                .Select(p => new RolePermissionEntity
                {
                    RoleId = (int)Enum.Parse<Role>(rp.Role),
                    PermissionId = (int)Enum.Parse<Permission>(p)
                }))
            .ToList();
    }
}
