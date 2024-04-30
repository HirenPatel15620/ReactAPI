using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Model.Models;

namespace Model.Data
{
    public partial class typescript_demoContext : DbContext
    {
        public typescript_demoContext()
        {
        }

        public typescript_demoContext(DbContextOptions<typescript_demoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<GeoJsonDatum> GeoJsonData { get; set; } = null!;
        public virtual DbSet<PostalCodeDatum> PostalCodeData { get; set; } = null!;
        public virtual DbSet<State> States { get; set; } = null!;
        public virtual DbSet<Suburb> Suburbs { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=PCE56\\SQL2017;DataBase=typescript_demo;User ID=sa;Password=tatva123;TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PostalCodeDatum>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("PostalCode_Data");

                entity.Property(e => e.Altitude).HasDefaultValueSql("((0))");

                entity.Property(e => e.AltitudeMode).HasColumnName("altitudeMode");
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.ToTable("state");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Suburb>(entity =>
            {
                entity.ToTable("Suburb");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.Body)
                    .HasColumnType("text")
                    .HasColumnName("body");

                entity.Property(e => e.Title)
                    .HasColumnType("text")
                    .HasColumnName("title");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
