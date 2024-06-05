using Digitall.Warehouse.Application.Abstractions.Persistence;
using Digitall.Warehouse.Domain.Entities.Products;

namespace Digitall.Persistance.EF.Repositories
{
    public class ProductSwatchRepository(WarehouseDbContext dbContext)
        : Repository<ProductSwatch>(dbContext), IProductSwatchRepository
    {
    }
}
