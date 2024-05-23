using Digitall.Warehouse.Domain.Abstraction;

namespace Digitall.Warehouse.Domain.Entities.Products;

public class ProductSize : Entity
{
    HashSet<ProductVariant> _productVariants = [];

    private ProductSize(string name, string? description) : base()
    {
        Name = name;
        Description = description;
    }

    public string Name { get; private set; }

    public string? Description { get; private set; }

    public IReadOnlyCollection<ProductVariant> Variants => _productVariants.ToList();

    public static ProductSize Create(string name, string? description)
    {
        return new ProductSize(name, description);
    }
}
