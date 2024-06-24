using Digitall.Persistance.EF.Infrastructure;
using Digitall.Warehouse.Application.Abstractions.Persistence;
using Digitall.Warehouse.Domain.Entities.Products;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Digitall.Persistance.EF.Repositories.Cached;

public class CachedProductsRepository(
    IProductRepository productRepository,
    IDistributedCache cache,
    WarehouseDbContext dbContext) : IProductRepository
{
    private readonly IProductRepository _productRepository = productRepository;
    private readonly IDistributedCache _cache = cache;
    private readonly WarehouseDbContext _dbContext = dbContext;

    public async Task AddAsync(Product product, CancellationToken cancellationToken)
    {
        await _productRepository.AddAsync(product, cancellationToken);
    }

    public async Task<Product?> GetByIdAsync(Guid productId, CancellationToken cancellationToken)
    {
        var cacheIdentifier = CacheIdentifierConstants.GetProductById(productId);
        var productValue = await _cache.GetStringAsync(cacheIdentifier);

        Product? product;
        if (productValue == null)
        {
            // no cache - set cache if not null
            product = await _productRepository.GetByIdAsync(productId, cancellationToken);
            if (product is null)
            {
                return product;
            }

            productValue = JsonConvert.SerializeObject(product);

            var options = new DistributedCacheEntryOptions()
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1)
            };

            await _cache.SetStringAsync(
                CacheIdentifierConstants.GetProductById(productId),
                productValue,
                options,
                cancellationToken);

            return product;
        }

        // deserialise
        product = JsonConvert.DeserializeObject<Product>(productValue,
            new JsonSerializerSettings()
            {
                ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
                ContractResolver = new PrivateResolver()
            });

        if (product is not null)
        {
            _dbContext.Set<Product>().Attach(product!);
        }

        return product;
    }

    public async Task<Product?> GetByIdWithBrandAsync(Guid productId, CancellationToken cancellationToken)
    {
        var cacheIdentifier = CacheIdentifierConstants.GetProductByIdWithBrand(productId);
        var productValue = await _cache.GetStringAsync(cacheIdentifier);
        
        Product? product;
        if (productValue == null)
        {
            product = await _productRepository.GetByIdWithBrandAsync(productId, cancellationToken);
            if (product == null)
            {
                return product;
            }

            productValue = JsonConvert.SerializeObject(product);
            
            var options = new DistributedCacheEntryOptions()
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1)
            };
            _cache.SetString(cacheIdentifier, productValue, options);
        }

        // deserialise
        product = JsonConvert.DeserializeObject<Product>(productValue,
            new JsonSerializerSettings()
            {
                ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
                ContractResolver = new PrivateResolver()
            });

        if (product is not null)
        {
            _dbContext.Set<Product>().Attach(product!);
        }

        return product;
    }

    public async Task<Product?> GetByIdWithProductVariantBySizeIdAsync(Guid productId, Guid sizeId, CancellationToken cancellationToken)
    {
        return await _productRepository.GetByIdWithProductVariantBySizeIdAsync(productId, sizeId, cancellationToken);
    }

    public void Remove(Product product)
    {
        _productRepository.Remove(product);
    }

    public async Task<ICollection<Product>> SearchProductsAsync(string title, int skip, int take, CancellationToken cancellationToken)
    {
        return await _productRepository.SearchProductsAsync(title, skip, take, cancellationToken);
    }

    public void Update(Product product)
    {
        _productRepository.Update(product);
    }
}
