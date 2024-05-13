using Digitall.Warehouse.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Digitall.Persistance.EF.Configuration.Entities
{
    public class ProductSizeConfiguration : IEntityTypeConfiguration<ProductSize>
    {
        public void Configure(EntityTypeBuilder<ProductSize> builder)
        {
            builder.HasKey(size => size.Id);

            builder
                .Property(size => size.Name)
                .IsRequired()
                .HasMaxLength(EntityTypeConstants.MaxLength50);

            builder.HasIndex(size => size.Name).IsUnique();

            builder
                .Property(size => size.Description)
                .HasMaxLength(EntityTypeConstants.MaxLength500);
        }
    }
}
