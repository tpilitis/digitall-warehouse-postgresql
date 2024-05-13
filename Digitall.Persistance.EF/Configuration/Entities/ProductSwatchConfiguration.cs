using Digitall.Warehouse.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Digitall.Persistance.EF.Configuration.Entities
{
    public class ProductSwatchConfiguration : IEntityTypeConfiguration<ProductSwatch>
    {
        public void Configure(EntityTypeBuilder<ProductSwatch> builder)
        {
            builder.HasKey(size => size.Id);

            builder
                .Property(size => size.Name)
                .IsRequired()
                .HasMaxLength(EntityTypeConstants.MaxLength50);

            builder.HasIndex(size => size.Name).IsUnique();
        }
    }
}
