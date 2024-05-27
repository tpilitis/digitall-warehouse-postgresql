using Digitall.Warehouse.Domain.Entities.Products;

namespace Digitall.Persistance.EF.Specifications.Products
{
    public class GetProductsByTitleSpecification : Specification<Product>
    {
        public GetProductsByTitleSpecification(string title, int skip, int take)
            : base(product => product.Title.Contains(title))
        {
            Skip = skip;
            Take = take;
            AsNoTracking = true;
        }
    }
}
