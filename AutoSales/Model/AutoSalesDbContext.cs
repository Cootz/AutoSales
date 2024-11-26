using Microsoft.EntityFrameworkCore;

namespace AutoSales.Model
{
    public class AutoSalesDbContext : DbContext
    {
        public DbSet<Car> Cars { get; set; } = default!;
        public DbSet<Sale> Sales { get; set; } = default!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=autosale.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>(entity =>
            {
                entity.ToTable("Cars");
                entity.HasKey(p => p.Id).HasName("PK_User");
            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.ToTable("Sales");
                entity.HasKey(p => p.Id).HasName("PK_Sales");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
