using Microsoft.EntityFrameworkCore;

namespace CodeFirstApproch_EntityFrame.Models
{
    public class StudentDbContext : DbContext //Microsoft.EntityFrameworkCore; 
    {
        public StudentDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<StudentModel> tbl_StudentUsingEntity { get; set; } //tbl_StudentUsingEntity this is table name 
    }
}
