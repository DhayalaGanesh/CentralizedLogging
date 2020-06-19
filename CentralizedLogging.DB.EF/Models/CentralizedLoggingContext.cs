using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CentralizedLogging.DB.EF.Models
{
    public partial class CentralizedLoggingContext : DbContext
    {
        public CentralizedLoggingContext()
        {
        }

        public CentralizedLoggingContext(DbContextOptions<CentralizedLoggingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Logs> Logs { get; set; }
        public virtual DbSet<ServicesList> ServicesList { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=DatabaseConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Logs>(entity =>
            {
                entity.HasKey(e => e.LogId)
                    .HasName("PK__Logs__5E548648CAF4601B");

                entity.ToTable("Logs", "CL");

                entity.Property(e => e.LogId).ValueGeneratedOnAdd();

                entity.Property(e => e.LogMessages)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Log)
                    .WithOne(p => p.Logs)
                    .HasForeignKey<Logs>(d => d.LogId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Logs__LogId__2C3393D0");
            });

            modelBuilder.Entity<ServicesList>(entity =>
            {
                entity.ToTable("ServicesList", "CL");

                entity.Property(e => e.ServiceName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
