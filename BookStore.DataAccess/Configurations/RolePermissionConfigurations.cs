using BookStore.CoreDomain.Enums;
using BookStore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

public class RolePermissionConfigurations : IEntityTypeConfiguration<RolePermissionEntity>
{
    public void Configure(EntityTypeBuilder<RolePermissionEntity> builder)
    {
        builder.HasKey(r => new { r.RoleId, r.PermissionId });

        var rolePermissions = ParseRolePermissions();

        builder.HasData(rolePermissions);
    }

    private List<RolePermissionEntity> ParseRolePermissions()
    {
        var rolePermissionsList = new List<RolePermissionEntity>();

        var configBuilder = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        var authorizationOptions = configBuilder
            .GetSection("AuthorizationOptions:RolePermissions")
            .Get<List<RolePermissionDto>>();

        if (authorizationOptions == null)
            return rolePermissionsList;

        foreach (var rolePermission in authorizationOptions)
        {
            if (Enum.TryParse(rolePermission.Role, out Role roleEnum))
            {
                foreach (var permission in rolePermission.Permission)
                {
                    if (Enum.TryParse(permission, out Permission permissionEnum))
                    {
                        rolePermissionsList.Add(new RolePermissionEntity
                        {
                            RoleId = (int)roleEnum,
                            PermissionId = (int)permissionEnum
                        });
                    }
                }
            }
        }

        return rolePermissionsList;
    }

    private class RolePermissionDto
    {
        public string Role { get; set; }
        public List<string> Permission { get; set; }
    }
}
