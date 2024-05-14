using Digitall.Warehouse.Domain.Abstraction;

namespace Digitall.Warehouse.Domain.Entities.Products;

public class ProductSwatch : Entity<Guid>
{
    public string Name { get; set; } = null!;

    public ICollection<ProductVariant> Variants { get; set; } = [];
}
