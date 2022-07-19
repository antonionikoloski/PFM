


using Microsoft.EntityFrameworkCore;
using pfm.Database.Entities;

namespace pfm.Database.Configurations
{
   public class TransactionEntityTypeConfiguration : IEntityTypeConfiguration<TransactionEntity>
  {
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<TransactionEntity> builder)
    {

      builder.ToTable("Transactions");
      builder.HasKey(x => x.id);
      builder.Property(x => x.beneficiaryname).IsRequired();
      builder.Property(x => x.Date).IsRequired();
      builder.Property(x => x.Direction).IsRequired();
      builder.Property(x => x.Amount).IsRequired();
      builder.Property(x => x.Currency).IsRequired();
      builder.Property(x => x.mcc);
      builder.Property(x => x.kind).IsRequired();
    }
  }
}