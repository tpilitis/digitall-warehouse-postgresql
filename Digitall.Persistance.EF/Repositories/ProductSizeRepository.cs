using Digitall.Warehouse.Application.Abstractions.Persistence;
using Digitall.Warehouse.Domain.Entities.Products;

namespace Digitall.Persistance.EF.Repositories;

public class ProductSizeRepository(WarehouseDbContext dbContext)
        : Repository<ProductSize>(dbContext), IProductSizeRepository
{
}
