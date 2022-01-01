using Horizon.Blog.Domain.Aggregates.ArticleFunctionAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Horizon.Blog.Infrastructure.EntityConfigurations
{
    public class ReviewConfig : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.ToTable("review");

            builder.HasKey(_ => _.Id);
            builder.Property(_ => _.Id)
               .HasColumnName("id")
               .IsRequired()
               .HasMaxLength(36);


            builder.Property(_ => _.Content)
                .HasColumnName("content");
            builder.OwnsOne(_ => _.CreationInfo, info =>
               {
                   info.Property(_ => _.CreatorId)
                   .HasColumnName("creator_id");
                   info.Property(_ => _.CreationTime)
                   .HasColumnName("creation_time");
               });
           

        }
    }
}
