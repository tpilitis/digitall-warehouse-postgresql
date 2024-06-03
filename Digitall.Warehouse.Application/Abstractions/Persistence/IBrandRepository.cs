using Digitall.Warehouse.Domain.Entities.Products;

namespace Digitall.Warehouse.Application.Abstractions.Persistence;

public interface IBrandRepository
{
    Task<Brand?> GetByIdAsync(Guid entityId, CancellationToken cancellationToken);

    Task AddAsync(Brand brand, CancellationToken cancellationToken);
}
