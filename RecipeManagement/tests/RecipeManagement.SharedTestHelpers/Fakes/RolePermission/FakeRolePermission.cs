namespace RecipeManagement.SharedTestHelpers.Fakes.RolePermission;

using AutoBogus;
using RecipeManagement.Domain.RolePermissions;
using RecipeManagement.Dtos.RolePermission;

public class FakeRolePermission
{
    public static RolePermission Generate(RolePermissionForCreationDto rolePermissionForCreationDto)
    {
        return RolePermission.Create(rolePermissionForCreationDto);
    }
}