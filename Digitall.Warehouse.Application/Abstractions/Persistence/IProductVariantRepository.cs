using Digitall.Warehouse.Domain.Entities.Products;

namespace Digitall.Warehouse.Application.Abstractions.Persistence
{
    public interface IProductVariantRepository
    {
        Task<List<ProductVariant>> GetVariantsAsync(Guid productId, CancellationToken cancellationToken);
    }
}
