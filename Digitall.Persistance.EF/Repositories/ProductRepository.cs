using Digitall.Warehouse.Application.Abstractions.Persistence;
using Digitall.Warehouse.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;

namespace Digitall.Persistance.EF.Repositories
{
    public class ProductRepository(WarehouseDbContext dbContext)
        : Repository<Product>(dbContext), IProductRepository
    {
        public void Remove(Product product)
        {
            DbContext.Set<Product>().Remove(product);
        }

        public async Task<ICollection<Product>> GetProductsByTitleAsync(string title)
        {
            return await DbContext
                .Set<Product>()
                .AsNoTracking()
                .Where(product => product.Title.Contains(title))
                .ToListAsync();
        }

        public async Task<Product?> GetByIdWithBrandAsync(Guid productId, CancellationToken cancellationToken)
        {
            return await DbContext
                .Set<Product>()
                .AsNoTracking()
                .Include(product => product.Brand)
                .Where(product => product.Id == productId)
                .FirstOrDefaultAsync(cancellationToken);
        }
    }
}
