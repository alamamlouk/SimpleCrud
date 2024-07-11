using Microsoft.EntityFrameworkCore;
using SimpleCrud.Models;

namespace SimpleCrud.Data
{
    public class ApplicationDBContext: DbContext
    {
        public ApplicationDBContext( DbContextOptions<ApplicationDBContext> options)
        : base(options)
        {
            
        }
        public DbSet<Store> Store { get; set; } = null!;
        public DbSet<Product> Product { get; set; } = null!;
    }
}
