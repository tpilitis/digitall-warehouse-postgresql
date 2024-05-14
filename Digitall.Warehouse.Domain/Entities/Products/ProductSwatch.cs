using Digitall.Warehouse.Domain.Abstraction;

namespace Digitall.Warehouse.Domain.Entities.Products;

public class ProductSwatch : IIdentifiable<Guid>
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public ICollection<ProductVariant> Variants { get; set; } = [];
}
