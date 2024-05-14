using Digitall.Warehouse.Domain.Entities.Products;

namespace Digitall.Warehouse.Application.Persistence
{
    public interface IProductRepository
    {
        Task<Product?> GetProductById(Guid productId);

        Task AddAsync(Product product);

        Task<ICollection<Product>> GetProductsByTitleAsync(string title);

        void Remove(Product product);
    }
}
