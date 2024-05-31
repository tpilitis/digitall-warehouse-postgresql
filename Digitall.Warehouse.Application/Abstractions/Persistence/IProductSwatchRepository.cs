using Digitall.Warehouse.Domain.Entities.Products;

namespace Digitall.Warehouse.Application.Abstractions.Persistence;

public interface IProductSwatchRepository 
    : IMutatableRepository<ProductSwatch>, IReadonlyRepository<ProductSwatch>
{
}
