using BookAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookAPI.Data.Configurations
{
    public class GenrConfiguration : IEntityTypeConfiguration<Genr>
    {
        public void Configure(EntityTypeBuilder<Genr> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(20).IsRequired(true);
            builder.Property(x => x.IsDeleted).HasDefaultValue(false);
            builder.Property(x => x.CreatedAt).HasDefaultValueSql("GETUTCDATE()");
            builder.Property(x => x.ModifiedAt).HasDefaultValueSql("GETUTCDATE()");            
        }
    }
}
