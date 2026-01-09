using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CRUD_WithWebAPI.Models
{
    public partial class Asp_DOT_NetCore_DBContext : DbContext
    {
        public Asp_DOT_NetCore_DBContext()
        {
        }

        public Asp_DOT_NetCore_DBContext(DbContextOptions<Asp_DOT_NetCore_DBContext> options)
            : base(options)
        {
        }
        public virtual DbSet<TblStudentUsingEntity> TblStudentUsingEntities { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblStudentUsingEntity>(entity =>
            {
                entity.ToTable("tbl_StudentUsingEntity");

                entity.Property(e => e.StudGender)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.StudName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
