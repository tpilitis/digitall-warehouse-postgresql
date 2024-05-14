using Digitall.Warehouse.Application.Persistence;
using Digitall.Warehouse.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;

namespace Digitall.Persistance.EF.Repositories
{
    public class CategoryRepository(WarehouseDbContext dbContext) : ICategoryRepository
    {
        WarehouseDbContext _dbContext = dbContext;

        public async Task AddAsync(Category category)
        {
            await _dbContext.Set<Category>()
                .AddAsync(category);
        }

        public async Task<Category?> GetCategoryByIdAsync(Guid categoryId)
        {
            return await _dbContext.Set<Category>()
                .SingleOrDefaultAsync(category => category.Id == categoryId);
        }

        public async Task<ICollection<Product>> GetCategoryProductsAsync(string categoryName)
        {
            var category = await _dbContext
                .Set<Category>()
                .Include(category => category.Products)
                .SingleOrDefaultAsync(category => category.Name == categoryName);

            if (category == null)
            {
                return [];
            }

            return category.Products;
        }
    }
}
