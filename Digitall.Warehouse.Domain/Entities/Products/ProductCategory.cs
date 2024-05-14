using Digitall.Warehouse.Domain.Abstraction;

namespace Digitall.Warehouse.Domain.Entities.Products;

public class ProductCategory(Guid id) : Entity(id)
{
    private ProductCategory(): this(Guid.NewGuid())
    {
    }

    public Guid ProductId { get; set; }

    public Guid CategoryId { get; set; }
}
