using Domain.Entities.SizeEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class SizeConfiguration : IEntityTypeConfiguration<Size>
    {
        public void Configure(EntityTypeBuilder<Size> builder)
        {
            builder.HasKey(s => s.Id);

            builder
                .HasMany(s => s.Products)
                .WithOne(p => p.Size)
                .HasForeignKey(p => p.SizeId);

        }
    }
}
