using Digitall.Warehouse.Application.Persistence;
using Digitall.Warehouse.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;

namespace Digitall.Persistance.EF.Repositories
{
    public class ProductRepository(WarehouseDbContext dbContext)
        : Repository<Product, Guid>(dbContext), IProductRepository
    {
        public void Remove(Product product)
        {
            DbContext.Set<Product>().Remove(product);
        }

        public async Task<Product?> GetProductById(Guid productId)
        {
            return await DbContext.Set<Product>()
                .SingleOrDefaultAsync(product => product.Id == productId);
        }

        public async Task<ICollection<Product>> GetProductsByTitleAsync(string title)
        {
            return await DbContext
                .Set<Product>()
                .Where(product => product.Title.Contains(title))
                .ToListAsync();
        }
    }
}
