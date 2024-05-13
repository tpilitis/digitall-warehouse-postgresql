using Digitall.Warehouse.Domain.Abstraction;

namespace Digitall.Warehouse.Domain.Entities.Products;

public class ProductCategory : IIdentifiable<Guid>
{
    public Guid Id { get; }

    public Guid ProductId { get; set; }

    public Guid CategoryId { get; set; }
}
