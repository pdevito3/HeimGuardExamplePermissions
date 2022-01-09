namespace RecipeManagement.Domain;

using System.Reflection;

public static class Permissions
{
    // Permissions marker - do not delete this comment
    public const string CanDeleteRecipe = "CanDeleteRecipe";
    public const string CanUpdateRecipe = "CanUpdateRecipe";
    public const string CanAddRecipe = "CanAddRecipe";
    public const string CanReadRecipes = "CanReadRecipes";
    public const string CanDeleteRolePermission = "CanDeleteRolePermission";
    public const string CanUpdateRolePermission = "CanUpdateRolePermission";
    public const string CanAddRolePermission = "CanAddRolePermission";
    public const string CanReadRolePermissions = "CanReadRolePermissions";
    
    public static List<string> List()
    {
        return typeof(Permissions)
            .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
            .Where(fi => fi.IsLiteral && !fi.IsInitOnly && fi.FieldType == typeof(string))
            .Select(x => (string)x.GetRawConstantValue())
            .ToList();
    }
}
