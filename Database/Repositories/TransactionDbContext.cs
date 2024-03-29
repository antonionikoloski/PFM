

using System.Reflection;
using Microsoft.EntityFrameworkCore;
using pfm.Database.Entities;

namespace pfm.Database.Repositories
{
    public class TransactionDbContext : DbContext
    {
          public DbSet<TransactionEntity> Transactions { get; set; }
          public DbSet<CategoryEntity> Categories { get; set; }
          public DbSet<SubCategoryEntity> SubCategories { get; set; }
          public DbSet<SplitsEntity> Splits { get; set; }
        public TransactionDbContext(DbContextOptions<TransactionDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}