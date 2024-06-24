using Digitall.Warehouse.Application.Abstractions.Cache;
using Digitall.Warehouse.Application.Abstractions.Persistence;
using Digitall.Warehouse.Domain.Entities.Products;

namespace Digitall.Persistance.EF.Repositories.Cached;

public class CachedProductsRepository(
    IProductRepository productRepository,
    ICache cacheService) : IProductRepository
{
    private readonly IProductRepository _productRepository = productRepository;
    private readonly ICache _cache = cacheService;

    public async Task AddAsync(Product product, CancellationToken cancellationToken)
    {
        await _productRepository.AddAsync(product, cancellationToken);
    }

    public async Task<Product?> GetByIdAsync(Guid productId, CancellationToken cancellationToken)
    {
        var cacheIdentifier = CacheIdentifierConstants.GetProductById(productId);
       
        var product = await _cache.GetOrSetCacheAsync(
            cacheIdentifier,
            async () => await _productRepository.GetByIdAsync(productId, cancellationToken),
            cancellationToken);

        return product;
    }

    public async Task<Product?> GetByIdWithBrandAsync(Guid productId, CancellationToken cancellationToken)
    {
        var cacheIdentifier = CacheIdentifierConstants.GetProductByIdWithBrand(productId);
       
        var product = await _cache.GetOrSetCacheAsync(
            cacheIdentifier,
            async () => await _productRepository.GetByIdWithBrandAsync(productId, cancellationToken),
            cancellationToken);

        return product;
    }

    public async Task<Product?> GetByIdWithProductVariantBySizeIdAsync(Guid productId, Guid sizeId, CancellationToken cancellationToken)
    {
        var cacheIdentifier = CacheIdentifierConstants.GetByIdWithProductVariantBySizeId(productId, sizeId);
        
        var product = await _cache.GetOrSetCacheAsync(
            cacheIdentifier,
            async () => await _productRepository.GetByIdWithProductVariantBySizeIdAsync(productId, sizeId, cancellationToken),
            cancellationToken);

        return product;
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
