namespace RecipeManagement.UnitTests.UnitTests.Domain.RolePermissions;

using RecipeManagement.Domain;
using RecipeManagement.Domain.RolePermissions;
using RecipeManagement.Wrappers;
using RecipeManagement.Dtos.RolePermission;
using Bogus;
using FluentAssertions;
using NUnit.Framework;

public class RolePermissionTests
{
    private readonly Faker _faker;

    public RolePermissionTests()
    {
        _faker = new Faker();
    }
    
    [Test]
    public void can_create_valid_rolepermission()
    {
        var permission = _faker.PickRandom(Permissions.List());
        var role = _faker.PickRandom(Roles.List());
        var newRolePermission = RolePermission.Create(new RolePermissionForCreationDto()
        {
            Permission = permission,
            Role = role
        });
        
        newRolePermission.Permission.Should().Be(permission);
        newRolePermission.Role.Should().Be(role);
    }
    
    [Test]
    public void can_NOT_create_rolepermission_with_invalid_role()
    {
        var rolePermission = () => RolePermission.Create(new RolePermissionForCreationDto()
        {
            Permission = _faker.PickRandom(Permissions.List()),
            Role = _faker.Lorem.Word()
        });
        rolePermission.Should().Throw<FluentValidation.ValidationException>();
    }
    
    [Test]
    public void can_NOT_create_rolepermission_with_invalid_permission()
    {
        var rolePermission = () => RolePermission.Create(new RolePermissionForCreationDto()
        {
            Role = _faker.PickRandom(Roles.List()),
            Permission = _faker.Lorem.Word()
        });
        rolePermission.Should().Throw<FluentValidation.ValidationException>();
    }
}