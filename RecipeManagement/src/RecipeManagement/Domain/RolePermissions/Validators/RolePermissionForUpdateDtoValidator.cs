namespace RecipeManagement.Domain.RolePermissions.Validators;

using RecipeManagement.Dtos.RolePermission;
using FluentValidation;

public class RolePermissionForUpdateDtoValidator: RolePermissionForManipulationDtoValidator<RolePermissionForUpdateDto>
{
    public RolePermissionForUpdateDtoValidator()
    {
        // add fluent validation rules that should only be run on update operations here
        //https://fluentvalidation.net/
    }
}