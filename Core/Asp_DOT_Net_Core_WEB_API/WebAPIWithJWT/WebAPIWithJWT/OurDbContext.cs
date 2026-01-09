using Microsoft.EntityFrameworkCore;
using WebAPIWithJWT.Model;

namespace WebAPIWithJWT
{
    public class OurDbContext : DbContext
    {
        public OurDbContext(DbContextOptions<OurDbContext> options) : base(options)
        {
            
        }

        public DbSet<UserModel> tbl_UserForJWT { get; set; }
    }
}
