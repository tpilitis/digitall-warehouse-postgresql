using Digitall.Warehouse.Domain.Entities.Products;

namespace Digitall.Warehouse.Application.Abstractions.Persistence
{
    public interface ICategoryRepository
    {
        Task<Category?> GetByIdAsync(Guid categoryId, CancellationToken cancellationToken);

        Task<ICollection<Category>> GetAllByIdsAsync(List<Guid> categoryIds, CancellationToken cancellationToken);

        Task<Category?> GetByNameAsync(string name);

        Task AddAsync(Category category, CancellationToken cancellationToken);

        Task<ICollection<Product>> GetCategoryProductsAsync(string categoryName);
    }
}
