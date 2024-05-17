using Digitall.Warehouse.Domain.Abstraction;

namespace Digitall.Warehouse.Domain.Entities.Products;

public class Category(Guid id) : Entity(id)
{
    public Category() : this(Guid.NewGuid())
    {
    }

    public string Name { get; set; } = null!;

    public ICollection<Product> Products { get; set; } = [];
}
