using Digitall.Persistance.EF.Specifications;
using Digitall.Persistance.EF.Specifications.Products;
using Digitall.Warehouse.Application.Abstractions.Persistence;
using Digitall.Warehouse.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Digitall.Persistance.EF.Repositories
{
    public class ProductRepository(WarehouseDbContext dbContext)
        : Repository<Product>(dbContext), IProductRepository
    {
        public void Remove(Product product)
        {
            DbContext.Set<Product>().Remove(product);
        }

        public async Task<ICollection<Product>> GetProductsByTitleAsync(string title)
        {
            return await DbContext
                .Set<Product>()
                .AsNoTracking()
                .Where(product => product.Title.Contains(title))
                .ToListAsync();
        }

        public async Task<Product?> GetByIdWithBrandAsync(Guid productId, CancellationToken cancellationToken)
        {
            var getByIdWithBrandSpecification = new GetProductByIdWithBrandSpecification(productId);
         
            return await ApplySpecification(getByIdWithBrandSpecification)
                .FirstOrDefaultAsync(cancellationToken);
        }

        private IQueryable<Product> ApplySpecification(Specification<Product> specification)
        {
            return SpecificationEvaluator.GetQuery(DbContext.Set<Product>(), specification);
        }
    }
}
