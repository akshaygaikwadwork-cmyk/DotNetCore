using Microsoft.EntityFrameworkCore;
using SomeCrud.Models;

namespace SomeCrud.Configurations;

public class ProductDbContext : DbContext
{
    public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<ProductModel> tblProducts { get; set; }
}