using Digitall.Warehouse.Application.Abstractions.Persistence;
using Digitall.Warehouse.Domain.Entities.Products;

namespace Digitall.Persistance.EF.Repositories;

public class BrandRepository(WarehouseDbContext dbContext) 
    : Repository<Brand>(dbContext), IBrandRepository
{
}
