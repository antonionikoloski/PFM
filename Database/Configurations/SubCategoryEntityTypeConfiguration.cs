

using Microsoft.EntityFrameworkCore;
using pfm.Database.Entities;

namespace pfm.Database.Configurations
{
    public class SubCategoryEntityTypeConfiguration : IEntityTypeConfiguration<SubCategoryEntity>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<SubCategoryEntity> builder)
        {
            builder.ToTable("SubCategories");
            builder.HasKey(x => x.code);
            builder.Property(x => x.name).IsRequired();
            builder.HasOne(x => x.Category).WithMany().HasForeignKey(x => x.parentcode);
            builder.HasOne(x => x.Transaction).WithMany().HasForeignKey(x => x.TransactionId);
            
        }
    }
}