using Digitall.Warehouse.Domain.Entities.Products;

namespace Digitall.Warehouse.Application.Persistence
{
    public interface ICategoryRepository
    {
        Task<Category?> GetByIdAsync(Guid categoryId);

        Task<Category?> GetByNameAsync(string name);

        Task AddAsync(Category category, CancellationToken cancellationToken);

        Task<ICollection<Product>> GetCategoryProductsAsync(string categoryName);
    }
}
