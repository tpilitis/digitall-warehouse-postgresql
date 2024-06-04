using Digitall.Warehouse.Domain.Entities.Products;

namespace Digitall.Persistance.EF.Specifications.Products;

public class GetProductByIdWithVariantBySizeIdSpecification : Specification<Product>
{
    public GetProductByIdWithVariantBySizeIdSpecification(Guid productId, Guid sizeId)
        :base(product => product.Id == productId)
    {
        AddInclude(product => product.Variants.Where(variant => variant.SizeId == sizeId));
    }
}
