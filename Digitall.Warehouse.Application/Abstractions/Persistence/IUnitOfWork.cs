namespace Digitall.Warehouse.Application.Abstractions.Persistence
{
    public interface IUnitOfWork
    {
        ICategoryRepository Categories { get; init; }

        IProductRepository Products { get; init; }

        IBrandRepository Brands { get; init; }

        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
