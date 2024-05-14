using Digitall.Warehouse.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Digitall.Persistance.EF.Configuration.Entities;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(category => category.Id);

        builder
            .Property(category => category.Name)
            .IsRequired()
            .HasMaxLength(EntityTypeConstants.MaxLength255);

        builder.HasIndex(category => category.Name).IsUnique();
    }
}
