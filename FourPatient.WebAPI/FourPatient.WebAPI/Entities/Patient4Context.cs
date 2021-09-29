using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using FourPatient.WebAPI;

#nullable disable

namespace ../FourPatient.DataAccess.Entities
{
    public partial class Patient4Context : DbContext
    {
        public Patient4Context()
        {
        }

        public Patient4Context(DbContextOptions<Patient4Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Accommodation> Accommodations { get; set; }
        public virtual DbSet<Cleanliness> Cleanlinesses { get; set; }
        public virtual DbSet<Covid> Covids { get; set; }
        public virtual DbSet<Hospital> Hospitals { get; set; }
        public virtual DbSet<Nursing> Nursings { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Accommodation>(entity =>
            {
                entity.ToTable("Accommodation");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AverageA).HasColumnType("decimal(3, 2)");
            });

            modelBuilder.Entity<Cleanliness>(entity =>
            {
                entity.ToTable("Cleanliness");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AverageCl).HasColumnType("decimal(3, 2)");
            });

            modelBuilder.Entity<Covid>(entity =>
            {
                entity.ToTable("Covid");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AverageC).HasColumnType("decimal(3, 2)");

                entity.Property(e => e.Covid1).HasColumnName("COVID");
            });

            modelBuilder.Entity<Hospital>(entity =>
            {
                entity.ToTable("Hospital");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

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

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AverageN).HasColumnType("decimal(3, 2)");
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.ToTable("Patient");

                entity.HasIndex(e => e.Email, "email")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.DoB).HasColumnType("date");

                entity.Property(e => e.Email)
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

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Comfort).HasColumnType("decimal(3, 2)");

                entity.Property(e => e.DatePosted).HasColumnType("datetime");

                entity.Property(e => e.Message)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.Accommodation)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.AccommodationId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("AccommodationReviewFK");

                entity.HasOne(d => d.Cleanliness)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.CleanlinessId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("CleanlinessReviewFK");

                entity.HasOne(d => d.Covid)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.CovidId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("CovidReviewFK");

                entity.HasOne(d => d.Hospital)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.Hospitalid)
                    .HasConstraintName("HospitalReviewFK");

                entity.HasOne(d => d.Nursing)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.NursingId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("NursingReviewFK");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("PatientReviewFK");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
