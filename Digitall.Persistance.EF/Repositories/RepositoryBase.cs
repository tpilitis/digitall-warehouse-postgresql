using Digitall.Persistance.EF.Specifications;
using Digitall.Warehouse.Domain.Abstraction;

namespace Digitall.Persistance.EF.Repositories
{
    public abstract class RepositoryBase<TEntity>(WarehouseDbContext dbContext)
         where TEntity : Entity
    {
        protected readonly WarehouseDbContext DbContext = dbContext;

        protected IQueryable<TEntity> ApplySpecification(Specification<TEntity> specification)
        {
            return SpecificationEvaluator.GetQuery(DbContext.Set<TEntity>(), specification);
        }
    }
}
