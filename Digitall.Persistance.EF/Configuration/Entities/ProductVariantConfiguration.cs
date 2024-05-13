using Digitall.Warehouse.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Digitall.Persistance.EF.Configuration.Entities;

public class ProductVariantConfiguration : IEntityTypeConfiguration<ProductVariant>
{
    public void Configure(EntityTypeBuilder<ProductVariant> builder)
    {
        builder.HasKey(variant => variant.Id);

        builder
            .HasOne(variant => variant.Size)
            .WithMany(size => size.Variants)
            .HasForeignKey(variant => variant.SizeId);

        builder
            .HasOne(variant => variant.Swatch)
            .WithMany(swatch => swatch.Variants)
            .HasForeignKey(variant => variant.SwatchId);
    }
}
