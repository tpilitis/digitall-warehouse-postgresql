using Digitall.Warehouse.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Digitall.Persistance.EF.Configuration.Entities
{
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.HasKey(b => b.Id);

            builder
                .Property(b => b.Name)
                .HasMaxLength(EntityTypeConstants.MaxLength255)
                .IsRequired();
        }
    }
}
