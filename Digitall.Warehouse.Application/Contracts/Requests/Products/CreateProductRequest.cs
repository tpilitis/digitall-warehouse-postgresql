namespace Digitall.Warehouse.Api.Contracts.Requests.Products;

public class CreateProductRequest
{
    public string Title { get; set; } = default!;

    public string Description { get; set; } = default!;

    public Money Price { get; set; } = default!;

    public Guid CategoryId { get; set; } = default!;

    public Guid? BrandId { get; set; } = default!;
}
