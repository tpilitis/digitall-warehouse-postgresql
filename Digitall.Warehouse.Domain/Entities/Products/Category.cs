using Digitall.Warehouse.Domain.Abstraction;

namespace Digitall.Warehouse.Domain.Entities.Products;

public class Category : Entity<Guid>
{
    public string Name { get; set; } = null!;

    public ICollection<Product> Products { get; set; } = [];
}
