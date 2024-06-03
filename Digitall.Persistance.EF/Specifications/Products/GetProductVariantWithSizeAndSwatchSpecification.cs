using Digitall.Warehouse.Domain.Entities.Products;

namespace Digitall.Persistance.EF.Specifications.Products
{
    public class GetProductVariantWithSizeAndSwatchSpecification : Specification<ProductVariant>
    {
        public GetProductVariantWithSizeAndSwatchSpecification(Guid productId)
            : base(variant => variant.ProductId == productId)
        {
            AsSplitQuery = true;

            AddInclude(variant => variant.Size);
            AddInclude(variant => variant.Swatch);
        }
    }
}
