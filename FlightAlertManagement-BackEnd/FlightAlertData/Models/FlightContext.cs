using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FlightAlertData.Models
{
    public partial class FlightContext : DbContext
    {
        public FlightContext()
        {
        }

        public FlightContext(DbContextOptions<FlightContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Alerts> Alerts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\ProjectModels;Database=Flight;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alerts>(entity =>
            {
                entity.HasKey(e => e.AlertId)
                    .HasName("PK__alerts__4B8FB03A003DD2E6");

                entity.ToTable("alerts");

                entity.Property(e => e.AlertId).HasColumnName("alert_id");

                entity.Property(e => e.FlightDestination)
                    .IsRequired()
                    .HasColumnName("flight_destination")
                    .HasMaxLength(255);

                entity.Property(e => e.FlightSource)
                    .IsRequired()
                    .HasColumnName("flight_source")
                    .HasMaxLength(255);

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.PriceThreshold)
                    .HasColumnName("price_threshold")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
