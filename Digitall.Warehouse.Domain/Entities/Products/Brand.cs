using Digitall.Warehouse.Domain.Abstraction;

namespace Digitall.Warehouse.Domain.Entities.Products;

public class Brand: Entity
{
    private HashSet<Product> _products = [];

    private Brand(string name) : base()
    {
        Name = name;
    }

    public string? Name { get; private set; }

    public IReadOnlyCollection<Product> Products => _products;

    public static Brand Create(string name)
    {
        return new Brand(name);
    }
}
