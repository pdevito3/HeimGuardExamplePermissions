namespace RecipeManagement.Dtos.RolePermission;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public abstract class RolePermissionForManipulationDto 
{
   public string Role { get; set; }
   public string Permission { get; set; }
}