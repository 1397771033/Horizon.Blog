using Horizon.Blog.Domain.Aggregates.ArticleAggreate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horizon.Blog.Infrastructure.EntityConfigurations
{
    public class ArticleConfig : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.ToTable("article");

            builder.HasKey(_ => _.Id);
            builder.Property(_ => _.Id)
                .HasColumnName("id")
                .HasMaxLength(36)
                .IsRequired();
            builder.Property(_ => _.Content)
                .HasColumnName("content");
            builder.OwnsOne(_ => _.CreationInfo, info =>
            {
                info.Property(_ => _.CreatorId)
                .HasColumnName("creator_id");
                info.Property(_ => _.CreationTime)
                .HasColumnName("creation_time");
            });
            builder.OwnsOne(_ => _.ModificationInfo, info =>
               {
                   info.Property(_ => _.ModificationTime)
                   .HasColumnName("modification_time");
                   info.Property(_ => _.ModifierId)
                   .HasColumnName("modifier_id");
               });
            builder.Property(_ => _.SortNum)
                .HasColumnName("sort_num");
            builder.Property(_ => _.Status)
                .HasColumnName("status");
            builder.Property(_ => _.Title)
                .HasColumnName("title");
            builder.Property(_ => _.Toped)
                .HasColumnName("toped");
                
        }
    }
}
