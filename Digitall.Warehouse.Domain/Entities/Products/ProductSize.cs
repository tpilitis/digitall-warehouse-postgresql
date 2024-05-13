using Digitall.Warehouse.Domain.Abstraction;

namespace Digitall.Warehouse.Domain.Entities.Products;

public class ProductSize : IIdentifiable<Guid>
{
    public Guid Id { get; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public ICollection<ProductVariant> Variants { get; set; } = [];
}
