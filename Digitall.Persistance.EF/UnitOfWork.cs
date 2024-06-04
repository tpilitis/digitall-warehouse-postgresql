using Digitall.Warehouse.Application.Abstractions.Persistence;
using Digitall.Warehouse.Domain.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace Digitall.Persistance.EF;

public class UnitOfWork(WarehouseDbContext dbContext) : IUnitOfWork
{
    private readonly WarehouseDbContext _dbContext = dbContext;

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        UpdateAuditableEntities();
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private void UpdateAuditableEntities()
    {
        var auditableEntries = _dbContext.ChangeTracker.Entries<IAuditable>();

        foreach (var auditableEntry in auditableEntries)
        {
            if (auditableEntry.State == EntityState.Added)
            {
                auditableEntry.Property(entity => entity.CreatedAt).CurrentValue = DateTime.UtcNow;
            }

            if (auditableEntry.State == EntityState.Modified)
            {
                auditableEntry.Property(entity => entity.ModifiedAt).CurrentValue = DateTime.UtcNow;
            }
        }
    }
}
