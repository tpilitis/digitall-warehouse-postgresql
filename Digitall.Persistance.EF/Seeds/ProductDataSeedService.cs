using Digitall.Warehouse.Application;
using Digitall.Warehouse.Domain.Entities.Products;

namespace Digitall.Persistance.EF.Seeds;

public class ProductDataSeedService : IDataSeedService
{
    private readonly WarehouseDbContext _context;

    public ProductDataSeedService(WarehouseDbContext context)
    {
        _context = context;
    }

    public void Seed()
    {
        SeedSizes();
        SeedBrand();
    }

    public void SeedBrand()
    {
        if (!_context.Brands.Any())
        {
            var brand = Brand.Create("LFC");

            _context.Brands.Add(brand);
            _context.SaveChanges();
        }
    }

    private void SeedSizes()
    {
        if (!_context.Sizes.Any())
        {
            _context.Sizes.AddRange(SeedClothSizes());
            _context.Sizes.AddRange(SeedShoeSizes());

            _context.SaveChanges();
        }
    }

    private static IEnumerable<ProductSize> SeedClothSizes()
    {
        var sizes = new Dictionary<string, string>()
        {
            { "S", "small" },
            { "M", "Medium" },
            { "L", "Large" },
            { "XL", "Extra Large" },
            { "XXL", "Double Extra Large" },
            { "XXXL", "Triple Extra Lanrge"}
        };

        return SeedSizes(sizes);
    }

    private static IEnumerable<ProductSize> SeedShoeSizes()
    {
        var sizes = new Dictionary<string, string>()
        {
            { "3", null! },
            { "3.5", null! },
            { "4", null! },
            { "4.5", null! },
            { "5", null! },
            { "5.5", null!},
            { "6", null! },
            { "6.5", null! },
            { "7", null! },
            { "7.5", null! },
            { "8", null! },
            { "8.5", null!},
            { "9", null! },
            { "9.5", null!},
            { "10", null! },
            { "10.5", null! },
            { "11", null! },
            { "11.5", null! },
            { "12", null! },
            { "13", null!}
        };

        return SeedSizes(sizes);
    }

    private static IEnumerable<ProductSize> SeedSizes(Dictionary<string, string> inputSizes)
        => inputSizes.Select(kvp => ProductSize.Create(kvp.Key, kvp.Value));
}
