using Digitall.Persistance.EF.Infrastructure;
using Digitall.Warehouse.Application.Abstractions.Cache;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Digitall.Persistance.EF.Repositories.Cached
{
    public class Cache(
        IDistributedCache cache,
        WarehouseDbContext dbContext) : ICache
    {
        public static readonly TimeSpan DefaultExpiryTime = TimeSpan.FromMinutes(1);

        private readonly IDistributedCache _cache = cache;
        private readonly WarehouseDbContext _dbContext = dbContext;

        public async Task<T?> GetOrSetCacheAsync<T>(
            string cacheIdentifier,
            Func<Task<T?>> getWithoutCache,
            CancellationToken cancellationToken,
            TimeSpan? timespan = null) where T : class
        {
            var cachedData = await _cache.GetStringAsync(cacheIdentifier);

            T? data;
            if (cachedData == null)
            {
                // no cache - set cache if not null
                data = await getWithoutCache();
                if (data is null)
                {
                    return data;
                }

                await SetCacheAsync(cacheIdentifier, data, cancellationToken);

                return data;
            }

            // deserialise
            data = JsonConvert.DeserializeObject<T>(
                cachedData,
                new JsonSerializerSettings()
                {
                    ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
                    ContractResolver = new PrivateResolver()
                })!;

            if (data is not null)
            {
                _dbContext.Set<T>().Attach(data!);
            }

            return data;
        }

        private async Task SetCacheAsync<T>(
            string cacheIdentifier,
            T? data,
            CancellationToken cancellationToken,
            TimeSpan? timespan = null) where T : class
        {
            string? cachedData;
            var jsonSettings = new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            cachedData = JsonConvert.SerializeObject(data, jsonSettings);

            var options = new DistributedCacheEntryOptions()
            {
                AbsoluteExpirationRelativeToNow = timespan ?? DefaultExpiryTime
            };

            await _cache.SetStringAsync(cacheIdentifier, cachedData, options, cancellationToken);
        }
    }
}
