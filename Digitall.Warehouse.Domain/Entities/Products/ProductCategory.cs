using Digitall.Warehouse.Domain.Abstraction;

namespace Digitall.Warehouse.Domain.Entities.Products;

public class ProductCategory : Entity
{
    private ProductCategory(Guid productId, Guid categoryId) : base()
    {
        ProductId = productId;
        CategoryId = categoryId;
    }

    public Guid ProductId { get; private set; }

    public Guid CategoryId { get; private set; }

    public static ProductCategory Create(Guid productId, Guid categoryId)
    {
        return new ProductCategory(productId, categoryId);
    }
}
