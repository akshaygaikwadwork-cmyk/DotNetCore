using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DatabaseContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-I5LLE3S\SQLEXPRESS;Initial Catalog=Asp_DOT_NetCore_DB;TrustServerCertificate=True;Trusted_Connection=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasMany(s => s.Courses) // Student can enroll in many Courses
                .WithMany(c => c.Students) // Course can have many Students
                .UsingEntity(j => j.ToTable("StudentCourses")); //Explicitly set the join table name
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }

    }
}
