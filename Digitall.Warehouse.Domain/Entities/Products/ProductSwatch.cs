using Digitall.Warehouse.Domain.Abstraction;

namespace Digitall.Warehouse.Domain.Entities.Products;

public class ProductSwatch(Guid id) : Entity(id)
{
    private ProductSwatch(): this(Guid.NewGuid())
    {
    }

    public string Name { get; set; } = null!;

    public ICollection<ProductVariant> Variants { get; set; } = [];
}
