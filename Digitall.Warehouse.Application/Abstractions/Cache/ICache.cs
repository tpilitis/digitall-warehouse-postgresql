namespace Digitall.Warehouse.Application.Abstractions.Cache
{
    public interface ICache
    {
        Task<T?> GetOrSetCacheAsync<T>(
        string cacheIdentifier,
        Func<Task<T?>> getWithoutCache,
        CancellationToken cancellationToken,
        TimeSpan? timespan = null)
        where T : class;
    }
}
