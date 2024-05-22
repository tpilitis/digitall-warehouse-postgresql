using Digitall.Warehouse.Domain.Abstraction;

namespace Digitall.Warehouse.Domain.Entities.Products;

public class Brand(Guid id) : Entity(id)
{
    private Brand() : this(Guid.NewGuid())
    {
    }

    public string? Name { get; set; }

    public ICollection<Product> Products { get; set; } = new List<Product>();
}
