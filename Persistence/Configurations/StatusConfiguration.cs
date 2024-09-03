using Domain.Entities.StatusEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class StatusConfiguration : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.HasKey(s => s.Id);

            builder
                .HasMany(s => s.Products)
                .WithOne(p => p.Status)
                .HasForeignKey(p => p.StatusId);
        }
    }
}
