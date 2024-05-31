using Digitall.Warehouse.Domain.Abstraction;

namespace Digitall.Warehouse.Application.Abstractions.Persistence
{
    public interface IReadonlyRepository<TEntity>
        where TEntity : Entity
    {
        Task<TEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}
