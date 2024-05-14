using Digitall.Warehouse.Domain.Abstraction;

namespace Digitall.Warehouse.Domain.Entities.Products;

public class ProductVariant : Entity<Guid>
{
    public Guid ProductId { get; set; }

    public Guid SizeId { get; set; }

    public ProductSize? Size { get; set; }

    public Guid SwatchId { get; set; }

    public ProductSwatch? Swatch { get; set; }

    public int Quantity { get; set; }
}
