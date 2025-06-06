﻿namespace BookStore.DataAccess;

public class AuthorizationOptions
{
    public List<RolePermissions> RolePermissions { get; set; } = [];
}

public class RolePermissions
{
    public string Role { get; set; } = string.Empty;

    public string[] Permissions { get; set; } = [];
}
