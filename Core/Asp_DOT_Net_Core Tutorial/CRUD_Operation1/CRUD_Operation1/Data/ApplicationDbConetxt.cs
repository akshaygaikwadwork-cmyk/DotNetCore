using CRUD_Operation1.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Operation1.Data
{
    public class ApplicationDbConetxt : DbContext
    {
        public ApplicationDbConetxt(DbContextOptions<ApplicationDbConetxt> options) : base(options) { }
        
        public DbSet<StudentModel> tbl_StudentList { get; set; }
    }
}
