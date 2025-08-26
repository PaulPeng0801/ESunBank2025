using Microsoft.EntityFrameworkCore;

namespace MonthlyRevenueAPI.Models
{
    public partial class PublicCompanyContext : DbContext
    {
        public PublicCompanyContext()
        {
        }

        public PublicCompanyContext(DbContextOptions<PublicCompanyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MonthlyRevenue> MonthlyRevenues { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=PublicCompany;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MonthlyRevenue>(entity =>
            {
                entity.HasKey(e => e.CompanyCode)
                    .HasName("PK__MonthlyR__11A0134A11BDF8F4");

                entity.ToTable("MonthlyRevenue");

                entity.HasIndex(e => e.CompanyName, "IDX_CompanyName");

                entity.HasIndex(e => new { e.CompanyName, e.Industry }, "IDX_CompanyName_Industry");

                entity.HasIndex(e => e.Industry, "IDX_Industry");

                entity.Property(e => e.CompanyCode).HasMaxLength(20);

                entity.Property(e => e.CompanyName).HasMaxLength(100);

                entity.Property(e => e.CurrentCumulativeRevenue).HasMaxLength(50);

                entity.Property(e => e.CurrentMonthRevenue).HasMaxLength(50);

                entity.Property(e => e.DataYearMonth).HasMaxLength(20);

                entity.Property(e => e.Industry).HasMaxLength(50);

                entity.Property(e => e.LastYearCumulativeRevenue).HasMaxLength(50);

                entity.Property(e => e.LastYearSameMonthRevenue).HasMaxLength(50);

                entity.Property(e => e.MonthOverMonthChange).HasMaxLength(50);

                entity.Property(e => e.Notes).HasMaxLength(300);

                entity.Property(e => e.PreviousMonthRevenue).HasMaxLength(50);

                entity.Property(e => e.PriorPeriodChange).HasMaxLength(50);

                entity.Property(e => e.ReportDate).HasMaxLength(20);

                entity.Property(e => e.YearOverYearChange).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
