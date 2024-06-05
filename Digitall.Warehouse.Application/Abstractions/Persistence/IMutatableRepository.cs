using Digitall.Warehouse.Domain.Abstraction;

namespace Digitall.Warehouse.Application.Abstractions.Persistence
{
    public interface IMutatableRepository<in TEntity>
        where TEntity : Entity
    {
        public Task AddAsync(TEntity entity, CancellationToken cancellationToken);

        public void Update(TEntity entity);
    }
}
