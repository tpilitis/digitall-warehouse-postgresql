using Digitall.Warehouse.Application.Persistence;
using Digitall.Warehouse.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;

namespace Digitall.Persistance.EF.Repositories
{
    public class CategoryRepository(WarehouseDbContext dbContext)
                : Repository<Category, Guid>(dbContext), ICategoryRepository
    {
        public async Task<Category?> GetCategoryByIdAsync(Guid categoryId)
        {
            return await DbContext.Set<Category>()
                .SingleOrDefaultAsync(category => category.Id == categoryId);
        }

        public async Task<ICollection<Product>> GetCategoryProductsAsync(string categoryName)
        {
            var category = await DbContext
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
