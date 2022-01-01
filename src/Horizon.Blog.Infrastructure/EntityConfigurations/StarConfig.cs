using Horizon.Blog.Domain.Aggregates.ArticleFunctionAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Horizon.Blog.Infrastructure.EntityConfigurations
{
    public class StarConfig : IEntityTypeConfiguration<Star>
    {
        public void Configure(EntityTypeBuilder<Star> builder)
        {
            builder.ToTable("star");

            builder.HasKey(_ => _.Id);
            builder.Property(_ => _.Id)
                .HasColumnName("id")
                .HasMaxLength(36)
                .IsRequired();

            builder.OwnsOne(_ => _.CreationInfo, info =>
               {
                   info.Property(_ => _.CreationTime)
                   .HasColumnName("creation_time");
                   info.Property(_ => _.CreatorId)
                   .HasColumnName("creator_id");
               });
        }
    }
}
