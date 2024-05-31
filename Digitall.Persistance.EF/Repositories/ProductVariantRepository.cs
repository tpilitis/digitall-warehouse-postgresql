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
            return DbContext
                .Set<ProductVariant>()
                .AsSplitQuery()
                .Include(pv => pv.Size)
                .Include(pv => pv.Swatch)
                .Where(pv => pv.ProductId == productId)
                .ToListAsync(cancellationToken);
        }
    }
}
