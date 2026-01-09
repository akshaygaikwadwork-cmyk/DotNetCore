using Microsoft.EntityFrameworkCore;
using TokenBasedAuth.Model;

namespace TokenBasedAuth.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Users> users { get; set; }
    }
}
