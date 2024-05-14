using Digitall.Warehouse.Application.Persistence;
using Digitall.Warehouse.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;

namespace Digitall.Persistance.EF.Repositories
{
    public class ProductRepository(WarehouseDbContext dbContext) : IProductRepository
    {
        private readonly WarehouseDbContext _dbContext = dbContext;

        public async Task AddAsync(Product product)
        {
           await _dbContext.Set<Product>()
                .AddAsync(product);
        }

        public void Remove(Product product)
        {
            _dbContext.Set<Product>().Remove(product);
        }

        public async Task<Product?> GetProductById(Guid productId)
        {
            return await _dbContext.Set<Product>()
                .SingleOrDefaultAsync(product => product.Id == productId);
        }

        public async Task<ICollection<Product>> GetProductsByTitleAsync(string title)
        {
            return await _dbContext
                .Set<Product>()
                .Where(product => product.Title.Contains(title))
                .ToListAsync();
        }
    }
}
