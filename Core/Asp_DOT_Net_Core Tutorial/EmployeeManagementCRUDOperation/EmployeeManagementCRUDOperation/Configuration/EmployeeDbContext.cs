using EmployeeManagementCRUDOperation.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementCRUDOperation.Configuration
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options)
            : base(options)
        {

        }

        public DbSet<EmployeeModel> tbl_employeeData { get; set; }
        public DbSet<Department> tbl_Department { get; set; }
    }
}
