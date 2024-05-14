using Digitall.Warehouse.Domain.Abstraction;

namespace Digitall.Warehouse.Domain.Entities.Products;

public class ProductSize(Guid id) : Entity(id)
{
    private ProductSize() : this(Guid.NewGuid())
    {
    }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public ICollection<ProductVariant> Variants { get; set; } = [];
}
