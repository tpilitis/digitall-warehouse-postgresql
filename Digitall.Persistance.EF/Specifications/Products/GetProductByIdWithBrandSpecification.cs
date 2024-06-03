using Digitall.Warehouse.Domain.Entities.Products;

namespace Digitall.Persistance.EF.Specifications.Products
{
    public class GetProductByIdWithBrandSpecification : Specification<Product>
    {
        public GetProductByIdWithBrandSpecification(Guid productId) 
            : base(product => product.Id == productId)
        {
            AddInclude(product => product.Brand);
        }
    }
}
