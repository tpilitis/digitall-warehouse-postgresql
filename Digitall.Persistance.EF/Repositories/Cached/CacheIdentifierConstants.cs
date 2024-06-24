namespace Digitall.Persistance.EF.Repositories.Cached
{
    public static class CacheIdentifierConstants
    {
        public static string GetProductById(Guid productId) => $"{nameof(GetProductById)}_{productId}";

        public static string GetProductByIdWithBrand(Guid productId) => $"{nameof(GetProductByIdWithBrand)}_{productId}";

        public static string GetByIdWithProductVariantBySizeId(Guid productId, Guid sizeId) => $"{nameof(GetByIdWithProductVariantBySizeId)}_{productId}_{sizeId}";
    }
}
