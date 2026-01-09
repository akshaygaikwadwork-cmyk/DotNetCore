using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LoginFormWithDatabaseFirstWithSession.Models
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

        public virtual DbSet<TblDepartment> TblDepartments { get; set; } = null!;
        public virtual DbSet<TblEmployee> TblEmployees { get; set; } = null!;
        public virtual DbSet<TblEmployeeDatum> TblEmployeeData { get; set; } = null!;
        public virtual DbSet<TblHotelDatum> TblHotelData { get; set; } = null!;
        public virtual DbSet<TblMstDepartment> TblMstDepartments { get; set; } = null!;
        public virtual DbSet<TblProduct> TblProducts { get; set; } = null!;
        public virtual DbSet<TblStudentUsingEntity> TblStudentUsingEntities { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblDepartment>(entity =>
            {
                entity.HasKey(e => e.DId);

                entity.ToTable("tbl_Department");

                entity.Property(e => e.DId).HasColumnName("D_Id");

                entity.Property(e => e.DepartmentName).HasColumnName("Department_name");
            });

            modelBuilder.Entity<TblEmployee>(entity =>
            {
                entity.HasKey(e => e.EmpId);

                entity.ToTable("tbl_Employee");

                entity.Property(e => e.ConfirmPassword)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.EmailId)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EmpGender)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.EmpName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmpSalary).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Password)
                    .HasMaxLength(300)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblEmployeeDatum>(entity =>
            {
                entity.ToTable("tbl_employeeData");

                entity.Property(e => e.Dob).HasColumnName("DOB");

                entity.Property(e => e.Fname)
                    .HasMaxLength(50)
                    .HasColumnName("FName");

                entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");

                entity.Property(e => e.Lname)
                    .HasMaxLength(50)
                    .HasColumnName("LName");

                entity.Property(e => e.Salary).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<TblHotelDatum>(entity =>
            {
                entity.HasKey(e => e.CustomerId);

                entity.ToTable("tbl_HotelData");

                entity.Property(e => e.CustomerName).HasMaxLength(100);

                entity.Property(e => e.DishImageName).HasMaxLength(800);

                entity.Property(e => e.DishName).HasMaxLength(100);

                entity.Property(e => e.IsDeleted).HasColumnName("Is_deleted");

                entity.Property(e => e.OrderDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TblMstDepartment>(entity =>
            {
                entity.ToTable("tbl_MstDepartment");

                entity.Property(e => e.DepartmentName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("department_Name");
            });

            modelBuilder.Entity<TblProduct>(entity =>
            {
                entity.ToTable("tblProducts");

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.Name).HasMaxLength(60);
            });

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
