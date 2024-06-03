using Digitall.Persistance.EF.Specifications.Products;
using Digitall.Warehouse.Application.Abstractions.Persistence;
using Digitall.Warehouse.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;

namespace Digitall.Persistance.EF.Repositories
{
    public class ProductVariantRepository(WarehouseDbContext dbContext) 
        : RepositoryBase<ProductVariant>(dbContext), IProductVariantRepository
    {
        public Task<List<ProductVariant>> GetVariantsAsync(Guid productId, CancellationToken cancellationToken)
        {
            var specification = new GetProductVariantWithSizeAndSwatchSpecification(productId);
            return ApplySpecification(specification)
                .ToListAsync(cancellationToken);
        }
    }
}
