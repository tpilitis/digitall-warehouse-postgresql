using Digitall.Warehouse.Domain.Abstraction;
using Digitall.Warehouse.Domain.Exceptions;

namespace Digitall.Warehouse.Domain.Entities.Products;

public class Product : Entity
{
    private HashSet<Category> _categories = [];
    private HashSet<ProductVariant> _productVariants = [];

    private Product(
        string title,
        string description,
        Guid? brandId)
        : base()
    {
        Title = title;
        Description = description;
        BrandId = brandId;

        // TODO: raise create domain event;
    }

    public string Title { get; private set; }

    public string? Description { get; private set; }

    public Brand? Brand { get; private set; }

    public Guid? BrandId { get; protected set; }

    public Price Price { get; private set; } = default!;

    public IReadOnlyCollection<Category> Categories => _categories;

    public IReadOnlyCollection<ProductVariant> Variants => _productVariants;

    public static Product Create(
        string title,
        string description,
        Price price,
        Guid? brandId,
        Category category)
    {
        var product = new Product(title, description, brandId);

        product.SetPrice(price);
        product.AddCategory(category);

        return product;
    }

    private void SetPrice(Price price)
    {
        Price = price;

        // TODO: Raise D-Event
    }

    public void AddCategory(Category category)
    {
        if (_categories.Contains(category))
        {
            // we can throw a custom exception,
            // but at this case we want to be silent - the category is already assigned to product
            return;
        }

        _categories.Add(category);

        // TODO: Raise D-Event
    }

    public void AddProductVariant(Guid sizeId, int quantity, Guid? swatchId)
    {
        if (_productVariants.Any(variant => variant.SizeId == sizeId))
        {
            throw new DuplicatedItemDomainException(DomainErrors.ProductVariant.DuplicatedItemBySize);
        }

        _productVariants.Add(ProductVariant.Create(Id, sizeId, quantity, swatchId));

        // TODO: Raise D-Event
    }
}
