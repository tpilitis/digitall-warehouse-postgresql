using Digitall.Warehouse.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Digitall.Persistance.EF.Configuration.Entities
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(product => product.Id);

            builder
                .Property(product => product.Title)
                .IsRequired()
                .HasMaxLength(EntityTypeConstants.MaxLength255);

            builder
                .Property(product => product.Description)
                .HasMaxLength(EntityTypeConstants.MaxLength500);

            builder
                .HasOne(p => p.Brand)
                .WithMany(p => p.Products)
                .HasForeignKey(p => p.BrandId);

            builder
                .ComplexProperty(product => product.Price, complexBuilder =>
                {
                    complexBuilder
                        .Property(price => price.Value)
                        .HasColumnType(EntityTypeConstants.Money)
                        .IsRequired();
 
                    complexBuilder
                        .Property(price => price.CurrencyCode)
                        .HasMaxLength(EntityTypeConstants.IsoCodeMaxLength)
                        .IsRequired();
                });       
        }
    }
}
