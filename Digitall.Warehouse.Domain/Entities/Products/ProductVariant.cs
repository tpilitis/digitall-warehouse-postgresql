using Digitall.Warehouse.Domain.Abstraction;

namespace Digitall.Warehouse.Domain.Entities.Products;

public class ProductVariant : Entity
{
    private ProductVariant(
        Guid productId,
        Guid sizeId,
        int quantity,
        Guid? swatchId) : base(Guid.Empty)
    {
        ProductId = productId;
        SizeId = sizeId;
        Quantity = quantity;
        SwatchId = swatchId;
    }

    public Guid ProductId { get; private set; }

    public Guid SizeId { get; private set; }

    public ProductSize? Size { get; private set; }

    public int Quantity { get; private set; }

    public Guid? SwatchId { get; private set; }

    public ProductSwatch? Swatch { get; private set; }

    public static ProductVariant Create(
        Guid productId,
        Guid sizeId,
        int quantity,
        Guid? swatchId)
    {
        return new ProductVariant(productId, sizeId, quantity, swatchId);
    }
}
