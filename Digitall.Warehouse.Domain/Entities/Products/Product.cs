using Digitall.Warehouse.Domain.Abstraction;
using System.ComponentModel.DataAnnotations;

namespace Digitall.Warehouse.Domain.Entities.Products
{
    public class Product : IIdentifiable<Guid>
    {
        public Guid Id { get; }

        [MaxLength(255)]
        public string Title { get; set; } = null!;

        [MaxLength(500)]
        public string? Description { get; set; }

        public Brand? Brand { get; set; }

        [Required]
        public Price? Price { get; set; }

        public ICollection<ProductCategory> ProductCategories { get; set; } = new List<ProductCategory>();
    }
}
