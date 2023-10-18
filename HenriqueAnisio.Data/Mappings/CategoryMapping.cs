using HenriqueAnisio.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HenriqueAnisio.Data.Mappings
{
    public class CategoryMapping : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(builder => builder.Name)
                .HasMaxLength(200)
                .IsRequired();

            builder.ToTable("Category");
        }
    }
}
