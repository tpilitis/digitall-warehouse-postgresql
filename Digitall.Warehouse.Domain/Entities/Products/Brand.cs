using Digitall.Warehouse.Domain.Abstraction;

namespace Digitall.Warehouse.Domain.Entities.Products;

public class Brand : Entity<Guid>
{
    public string? Name { get; set; }

    public ICollection<Product> Products { get; set; } = new List<Product>();
}
