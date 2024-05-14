using Digitall.Warehouse.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Digitall.Persistance.EF.Configuration.Entities;

public class BrandConfiguration : IEntityTypeConfiguration<Brand>
{
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        builder.HasKey(brand => brand.Id);

        builder
            .Property(brand => brand.Name)
            .HasMaxLength(EntityTypeConstants.MaxLength255)
            .IsRequired();

        builder.HasIndex(brand => brand.Name).IsUnique();
    }
}
