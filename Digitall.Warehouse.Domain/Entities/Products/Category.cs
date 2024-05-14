using Digitall.Warehouse.Domain.Abstraction;

namespace Digitall.Warehouse.Domain.Entities.Products;

public class Category : IIdentifiable<Guid>
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public ICollection<Product> Products { get; set; } = [];
}
