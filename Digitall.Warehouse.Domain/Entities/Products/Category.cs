using Digitall.Warehouse.Domain.Abstraction;

namespace Digitall.Warehouse.Domain.Entities.Products;

public class Category : Entity
{
    private HashSet<Product> _products = [];

    private Category(string name) : base()
    {
        Name = name;
    }

    public string Name { get; private set; }

    public IReadOnlyCollection<Product> Products => _products;

    public static Category Create(string name)
    {
        return new Category(name);
    }
}
