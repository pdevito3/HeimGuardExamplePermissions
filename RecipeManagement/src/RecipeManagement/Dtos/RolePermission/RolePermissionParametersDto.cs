namespace RecipeManagement.Dtos.RolePermission;

using RecipeManagement.Dtos.Shared;

public class RolePermissionParametersDto : BasePaginationParameters
{
    public string Filters { get; set; }
    public string SortOrder { get; set; }
}