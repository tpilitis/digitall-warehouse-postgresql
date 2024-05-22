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
                .Where(product => product.Title.Contains(title))
                .ToListAsync();
        }
    }
}
