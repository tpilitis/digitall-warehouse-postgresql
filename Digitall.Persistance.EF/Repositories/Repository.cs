using Digitall.Warehouse.Domain.Abstraction;

namespace Digitall.Persistance.EF.Repositories
{
    public abstract class Repository<TEntity, TId>(WarehouseDbContext dbContext) where TEntity : Entity<TId>
    {
        protected readonly WarehouseDbContext DbContext = dbContext;

        public async Task AddAsync(TEntity entity)
        {
            await DbContext.Set<TEntity>().AddAsync(entity);
        }

        public void Update(TEntity entity)
        {
            DbContext.Set<TEntity>().Update(entity);
        }
    }
}
