using Digitall.Warehouse.Domain.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace Digitall.Persistance.EF.Repositories
{
    public abstract class Repository<TEntity>(WarehouseDbContext dbContext) : RepositoryBase<TEntity>(dbContext)
        where TEntity : Entity
    {
        public async Task AddAsync(TEntity entity, CancellationToken cancellationToken)
        {
            await DbContext.Set<TEntity>().AddAsync(entity, cancellationToken);
        }

        public void Update(TEntity entity)
        {
            DbContext.Set<TEntity>().Update(entity);
        }

        public async Task<TEntity?> GetByIdAsync(Guid entityId, CancellationToken cancellationToken)
        {
            return await DbContext
                .Set<TEntity>()
                .SingleOrDefaultAsync(entity => entity.Id == entityId, cancellationToken);
        }
    }
}
