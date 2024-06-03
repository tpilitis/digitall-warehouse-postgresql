namespace Digitall.Warehouse.Application.Contracts.Requests.Products;

public class ProductVariantRequest
{
    public Guid ProductId { get; private set; }

    public Guid SizeId { get; set; }

    public Guid? SwatchId { get; set; }

    public int Quantity { get; set; }

    public void SetProductId(Guid productId) => ProductId = productId;
}
