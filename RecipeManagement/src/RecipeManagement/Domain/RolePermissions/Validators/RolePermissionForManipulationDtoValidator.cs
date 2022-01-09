namespace RecipeManagement.Domain.RolePermissions.Validators;

using RecipeManagement.Dtos.RolePermission;
using RecipeManagement.Domain;
using FluentValidation;

public class RolePermissionForManipulationDtoValidator<T> : AbstractValidator<T> where T : RolePermissionForManipulationDto
{
    public RolePermissionForManipulationDtoValidator()
    {
        RuleFor(rp => rp.Permission)
            .Must(BeAnExistingPermission)
            .WithMessage("Please use a valid role.");
        RuleFor(rp => rp.Role)
            .Must(BeAnExistingRole)
            .WithMessage("Please use a valid role.");
    }
    
    private static bool BeAnExistingPermission(string permission)
    {
        return Permissions.List().Contains(permission);
    }

    private static bool BeAnExistingRole(string role)
    {
        return Roles.List().Contains(role);
    }
}