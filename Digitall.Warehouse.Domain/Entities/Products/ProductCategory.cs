using Digitall.Warehouse.Domain.Abstraction;

namespace Digitall.Warehouse.Domain.Entities.Products;

public class ProductCategory : Entity<Guid>
{
    public Guid ProductId { get; set; }

    public Guid CategoryId { get; set; }
}
