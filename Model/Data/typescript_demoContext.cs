using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Model.Models;

namespace Model.Data
{
    public partial class typeScript_demoContext : DbContext
    {
        public typeScript_demoContext()
        {
        }

        public typeScript_demoContext(DbContextOptions<typeScript_demoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Stack> Stacks { get; set; } = null!;
        public virtual DbSet<StackDetail> StackDetails { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=PCE56\\SQL2017;DataBase=typeScript_demo;User ID=sa;Password=tatva123;TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Stack>(entity =>
            {
                entity.ToTable("Stack");

                entity.Property(e => e.Id).HasColumnName("id");
            });

            modelBuilder.Entity<StackDetail>(entity =>
            {
                entity.HasOne(d => d.Stack)
                    .WithMany(p => p.StackDetails)
                    .HasForeignKey(d => d.StackId)
                    .HasConstraintName("FK_Stack_StackDetails");
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
