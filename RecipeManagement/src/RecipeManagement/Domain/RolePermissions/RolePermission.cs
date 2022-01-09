namespace RecipeManagement.Domain.RolePermissions;

using RecipeManagement.Dtos.RolePermission;
using RecipeManagement.Domain.RolePermissions.Mappings;
using RecipeManagement.Domain.RolePermissions.Validators;
using AutoMapper;
using FluentValidation;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;


public class RolePermission : BaseEntity
{
    public string Role { get; private set; }

    public string Permission { get; private set; }


    public static RolePermission Create(RolePermissionForCreationDto rolePermissionForCreationDto)
    {
        new RolePermissionForCreationDtoValidator().ValidateAndThrow(rolePermissionForCreationDto);
        var mapper = new Mapper(new MapperConfiguration(cfg => {
            cfg.AddProfile<RolePermissionProfile>();
        }));
        var newRolePermission = mapper.Map<RolePermission>(rolePermissionForCreationDto);
        
        return newRolePermission;
    }
        
    public void Update(RolePermissionForUpdateDto rolePermissionForUpdateDto)
    {
        new RolePermissionForUpdateDtoValidator().ValidateAndThrow(rolePermissionForUpdateDto);
        var mapper = new Mapper(new MapperConfiguration(cfg => {
            cfg.AddProfile<RolePermissionProfile>();
        }));
        mapper.Map(rolePermissionForUpdateDto, this);
    }
    
    private RolePermission() { } // For EF
}