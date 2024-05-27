using Digitall.Warehouse.Domain.Entities.Products;

namespace Digitall.Warehouse.Application.Abstractions.Persistence
{
    public interface IProductRepository
    {
        Task<Product?> GetByIdAsync(Guid productId, CancellationToken cancellationToken);

        Task<Product?> GetByIdWithBrandAsync(Guid productId, CancellationToken cancellationToken);

        Task AddAsync(Product product, CancellationToken cancellationToken);

        Task<ICollection<Product>> GetProductsByTitleAsync(string title);

        void Remove(Product product);
    }
}
