using Microsoft.EntityFrameworkCore;
using StudentApplication.Models;

namespace StudentApplication.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        
        public DbSet<StudentModel> tbl_StudentNew {  get; set; }
    }
}
