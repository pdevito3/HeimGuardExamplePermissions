namespace RecipeManagement.Databases;


using RecipeManagement.Domain.Recipes;
using RecipeManagement.Domain;
using RecipeManagement.Services;
using RecipeManagement.Domain.RolePermissions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Threading;
using System.Threading.Tasks;

public class RecipesDbContext : DbContext
{
    private readonly ICurrentUserService _currentUserService;

    public RecipesDbContext(
        DbContextOptions<RecipesDbContext> options, ICurrentUserService currentUserService) : base(options)
    {
        _currentUserService = currentUserService;
    }

    #region DbSet Region - Do Not Delete
    public DbSet<RolePermission> RolePermissions { get; set; }

    public DbSet<Recipe> Recipes { get; set; }
    #endregion DbSet Region - Do Not Delete

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        UpdateAuditFields();
        return base.SaveChangesAsync(cancellationToken);
    }

    public override int SaveChanges()
    {
        UpdateAuditFields();
        return base.SaveChanges();
    }
        
    private void UpdateAuditFields()
    {
        var now = DateTime.UtcNow;
        foreach (var entry in ChangeTracker.Entries<BaseEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.UpdateCreationProperties(now, _currentUserService?.UserId);
                    entry.Entity.UpdateModifiedProperties(now, _currentUserService?.UserId);
                    break;

                case EntityState.Modified:
                    entry.Entity.UpdateModifiedProperties(now, _currentUserService?.UserId);
                    break;
                
                case EntityState.Deleted:
                    // deleted_at
                    break;
            }
        }
    }
}
