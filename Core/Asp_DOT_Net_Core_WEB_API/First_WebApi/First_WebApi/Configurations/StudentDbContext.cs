using First_WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace First_WebApi.Configurations
{
    public class StudentDbContext : DbContext 
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
        {
                
        }

        public DbSet<StudentRegModel> tbl_StudentRegData { get; set; }
    }
}
