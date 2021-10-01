using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace FourPatient.DataAccess.Entities
{
    public partial class _4PatientContext : DbContext
    {
        public _4PatientContext()
        {
        }

        public _4PatientContext(DbContextOptions<_4PatientContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Accommodation> Accommodation { get; set; }
        public virtual DbSet<Cleanliness> Cleanliness { get; set; }
        public virtual DbSet<Covid> Covid { get; set; }
        public virtual DbSet<Hospital> Hospitals { get; set; }
        public virtual DbSet<Nursing> Nursing { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Accommodation>(entity =>
            {
                entity.ToTable("Accommodation");

                entity.Property(e => e.AverageA).HasColumnType("decimal(3, 2)");
            });

            modelBuilder.Entity<Cleanliness>(entity =>
            {
                entity.ToTable("Cleanliness");

                entity.Property(e => e.AverageCl).HasColumnType("decimal(3, 2)");
            });

            modelBuilder.Entity<Covid>(entity =>
            {
                entity.ToTable("Covid");

                entity.Property(e => e.AverageC).HasColumnType("decimal(3, 2)");

                entity.Property(e => e.Covid1).HasColumnName("COVID");
            });

            modelBuilder.Entity<Hospital>(entity =>
            {
                entity.ToTable("Hospital");

                entity.Property(e => e.Accomodations).HasColumnType("decimal(3, 2)");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Cleanliness).HasColumnType("decimal(3, 2)");

                entity.Property(e => e.Comfort).HasColumnType("decimal(3, 2)");

                entity.Property(e => e.Covid).HasColumnType("decimal(3, 2)");

                entity.Property(e => e.Departments)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Nursing).HasColumnType("decimal(3, 2)");

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Nursing>(entity =>
            {
                entity.ToTable("Nursing");

                entity.Property(e => e.AverageN).HasColumnType("decimal(3, 2)");
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.ToTable("Patient");

                entity.HasIndex(e => e.Email, "UQ__Patient__A9D1053470DDEB3B")
                    .IsUnique();

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.DoB).HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.ToTable("Review");

                entity.Property(e => e.Comfort).HasColumnType("decimal(3, 2)");

                entity.Property(e => e.DatePosted).HasColumnType("datetime");

                entity.Property(e => e.Message)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.Accommodation)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.AccommodationId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Review__Accommod__489AC854");

                entity.HasOne(d => d.Cleanliness)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.CleanlinessId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Review__Cleanlin__4B7734FF");

                entity.HasOne(d => d.Covid)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.CovidId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Review__CovidId__4A8310C6");

                entity.HasOne(d => d.Hospital)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.Hospitalid)
                    .HasConstraintName("FK__Review__Hospital__47A6A41B");

                entity.HasOne(d => d.Nursing)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.NursingId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Review__NursingI__498EEC8D");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK__Review__PatientI__46B27FE2");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
