using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entities.ProductEntity;

namespace Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(pr => pr.Id);

            builder
                .HasOne(pr => pr.Category)
                .WithMany(c => c.Products);

            builder
                .HasOne(pr => pr.Brand)
                .WithMany(b => b.Products);

            builder
                .HasOne(pr => pr.Size)
                .WithMany(s => s.Products);

            builder
                .HasOne(pr => pr.Status)
                .WithMany(s => s.Products);
        }
    }
}
