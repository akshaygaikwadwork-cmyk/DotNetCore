using CRUD_Operation_JqueryAJAX.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Operation_JqueryAJAX.Configuration
{
    public class HotelDbContext : DbContext
    {
        public HotelDbContext(DbContextOptions<HotelDbContext> options) : base(options)
        {
                
        }

        public DbSet<HotelModel> tbl_HotelData { get; set; }
    }
}
