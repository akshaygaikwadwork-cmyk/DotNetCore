using CQRS_DesignPrin_WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRS_DesignPrin_WebAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<EmployeeModel> tbl_EmployeeNew {  get; set; }

    }
}
