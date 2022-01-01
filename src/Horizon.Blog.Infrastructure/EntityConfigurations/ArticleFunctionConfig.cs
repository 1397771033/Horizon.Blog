using Horizon.Blog.Domain.Aggregates.ArticleFunctionAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Horizon.Blog.Infrastructure.EntityConfigurations
{
    public class ArticleFunctionConfig : IEntityTypeConfiguration<ArticleFunction>
    {
        public void Configure(EntityTypeBuilder<ArticleFunction> builder)
        {
            builder.ToTable("article_function");

            builder.HasKey(_ => _.Id);
            builder.Property(_ => _.Id)
                .HasColumnName("id")
                .HasMaxLength(36)
                .IsRequired();

            builder.HasMany(_ => _.Reviews).WithOne().HasForeignKey("article_function_id");

            builder.Property(_ => _.ArticleId).HasColumnName("article_id");
        }
    }
}
