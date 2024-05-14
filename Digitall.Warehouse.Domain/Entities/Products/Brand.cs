using Digitall.Warehouse.Domain.Abstraction;
using System.ComponentModel.DataAnnotations;

namespace Digitall.Warehouse.Domain.Entities.Products;

public class Brand : IIdentifiable<Guid>
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public ICollection<Product> Products { get; set; } = new List<Product>();
}
