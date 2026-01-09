using Microsoft.EntityFrameworkCore;
using Practice2.Model;

namespace Practice2.Data
{
    public class AppliDbContext : DbContext
    {
        public AppliDbContext(DbContextOptions<AppliDbContext> options) : base (options) { }
        
        public DbSet<StudentModel> StudentsTempTbl { get; set; }
    }
}
