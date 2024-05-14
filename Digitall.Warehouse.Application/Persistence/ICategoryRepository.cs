using Digitall.Warehouse.Domain.Entities.Products;

namespace Digitall.Warehouse.Application.Persistence
{
    public interface ICategoryRepository
    {
        Task<Category?> GetByIdAsync(Guid categoryId);

        Task AddAsync(Category category);

        Task<ICollection<Product>> GetCategoryProductsAsync(string categoryName);
    }
}
