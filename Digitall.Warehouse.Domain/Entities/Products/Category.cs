using Digitall.Warehouse.Domain.Abstraction;

namespace Digitall.Warehouse.Domain.Entities.Products
{
    public class Category : IIdentifiable<Guid>
    {
        public Guid Id { get; }

        public string Name { get; set; }

        public ICollection<ProductCategory> ProductCategories { get; set; } = [];
    }
}
