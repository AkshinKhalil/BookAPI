using BookAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookAPI.Data.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.Property(X => X.Name).HasMaxLength(56).IsRequired(true);
            builder.Property(X => X.SalePrice).IsRequired(true).HasColumnType("decimal(18,2)");
            builder.Property(X => X.CostPrice).IsRequired(true).HasColumnType("decimal(18,2)");
            builder.Property(X => X.IsDeleted).HasDefaultValue(false);
            builder.Property(X => X.Image).HasMaxLength(150).IsRequired(false);
            builder.Property(X => X.CreatedAt).HasDefaultValueSql("GETUTCDATE()");
            builder.HasOne(X=>X.Author).WithMany(X=>X.Books).OnDelete(DeleteBehavior.NoAction);

        }
    }
}
