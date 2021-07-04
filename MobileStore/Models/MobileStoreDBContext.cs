using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MobileStore.Models
{
    public partial class MobileStoreDBContext : DbContext
    {
        public MobileStoreDBContext()
        {
        }

        public MobileStoreDBContext(DbContextOptions<MobileStoreDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MobileBrandRecord> MobileBrandRecords { get; set; }
        public virtual DbSet<MobileSellRecord> MobileSellRecords { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AI");

            modelBuilder.Entity<MobileBrandRecord>(entity =>
            {
                entity.ToTable("MobileBrandRecord");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.MobileBrand)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<MobileSellRecord>(entity =>
            {
                entity.ToTable("MobileSellRecord");

                entity.Property(e => e.MobileModel)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Price)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.SellDate).HasColumnType("datetime");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.MobileSellRecords)
                    .HasForeignKey(d => d.BrandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MobileSellRecord_MobileBrandRecord");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
