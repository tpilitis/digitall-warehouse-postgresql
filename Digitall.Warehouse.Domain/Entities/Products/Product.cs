using Digitall.Warehouse.Domain.Abstraction;

namespace Digitall.Warehouse.Domain.Entities.Products;

public class Product : Entity
{
    private HashSet<Category> _categories = [];
    private HashSet<ProductVariant> _productVariants = [];

    private Product(
        string title,
        string description,
        Price price,
        ICollection<Category> categories,
        Brand? brand)
        : base()
    {
        _categories = categories.Distinct().ToHashSet();
        Title = title;
        Description = description;
        Price = price;
        Brand = brand;

        // TODO: raise create domain event;
    }

    public string Title { get; private set; }

    public string? Description { get; private set; }

    public Brand? Brand { get; private set; }

    public Guid BrandId { get; protected set; }

    public Price Price { get; private set; }

    public IReadOnlyCollection<Category> Categories => _categories;

    public IReadOnlyCollection<ProductVariant> Variants => _productVariants;

    public static Product Create(
        string title,
        string description,
        Price price,
        ICollection<Category> categories,
        Brand? brand)
    {
        return new Product(title, description, price, categories, brand);
    }
}
