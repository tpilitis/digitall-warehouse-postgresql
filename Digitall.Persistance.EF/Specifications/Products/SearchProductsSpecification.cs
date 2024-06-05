using Digitall.Warehouse.Domain.Entities.Products;

namespace Digitall.Persistance.EF.Specifications.Products
{
    public class SearchProductsSpecification : Specification<Product>
    {
        public SearchProductsSpecification(string keyword, int skip, int take)
            : base(product => product.Title.Contains(keyword) 
                    || (!string.IsNullOrEmpty(product.Description) && product.Description!.Contains(keyword)))
        {
            Skip = skip;
            Take = take;
            AsNoTracking = true;
        }
    }
}
