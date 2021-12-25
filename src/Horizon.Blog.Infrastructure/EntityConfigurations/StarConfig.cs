using Horizon.Blog.Domain.Aggregates.StarAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            builder.Property(_ => _.ArticleId)
                .HasColumnName("article_id");
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
