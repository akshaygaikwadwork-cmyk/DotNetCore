using Microsoft.EntityFrameworkCore;
using Practice1.Model;

namespace Practice1.Data
{
    public class StudentDBContextTest : DbContext
    {
        public StudentDBContextTest(DbContextOptions<StudentDBContextTest> options) : base(options)
        {
            
        }

        public DbSet<StudentTemp> studentTemp {  get; set; }
    }
}
