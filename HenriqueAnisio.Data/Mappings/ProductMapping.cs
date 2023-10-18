using HenriqueAnisio.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HenriqueAnisio.Data.Mappings
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(builder => builder.Name)
                .HasColumnType("varchar")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(builder => builder.Description)
                .HasColumnType("varchar")
                .HasMaxLength(1000);

            builder.Property(builder => builder.Price)
                .HasColumnType("decimal")
                .IsRequired();

            builder.ToTable("Product");
        }
    }
}
