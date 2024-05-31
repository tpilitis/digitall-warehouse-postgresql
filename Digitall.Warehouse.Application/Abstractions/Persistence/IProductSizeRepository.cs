using Digitall.Warehouse.Domain.Entities.Products;

namespace Digitall.Warehouse.Application.Abstractions.Persistence
{
    public interface IProductSizeRepository
        : IMutatableRepository<ProductSize>, IReadonlyRepository<ProductSize>
    {
    }
}
