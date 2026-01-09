using Microsoft.EntityFrameworkCore;

namespace CodeFirstApproch_CRUDPractice.Model
{
    public class EmpDbContext : DbContext
    {
        public EmpDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<EmployeeModel> tbl_Employee { get; set; }
    }
}
