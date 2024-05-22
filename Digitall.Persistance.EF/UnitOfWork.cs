using Digitall.Warehouse.Application.Abstractions.Persistence;
using Digitall.Warehouse.Domain.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace Digitall.Persistance.EF;

public class UnitOfWork(
    WarehouseDbContext dbContext,
    ICategoryRepository categoryRepository,
    IProductRepository productRepository,
    IBrandRepository brandRepository) : IUnitOfWork
{
    private readonly WarehouseDbContext _dbContext = dbContext;

    public ICategoryRepository Categories { get; init; } = categoryRepository;

    public IProductRepository Products { get; init; } = productRepository;

    public IBrandRepository Brands { get; init; } = brandRepository;

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
