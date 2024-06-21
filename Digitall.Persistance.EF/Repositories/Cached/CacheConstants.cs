namespace Digitall.Persistance.EF.Repositories.Cached
{
    public static class CacheConstants
    {
        public static string GetProductByIdCacheIdentifier(Guid productId) => $"GetProductById_{productId}"; 
    }
}
