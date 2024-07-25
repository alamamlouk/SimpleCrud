using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using SimpleCrud.Entity;

namespace SimpleCrud.Data
{
    public class ApplicationDBContext: DbContext
    {
        public ApplicationDBContext( DbContextOptions<ApplicationDBContext> options)
        : base(options)
        {
          
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Store>()
                .HasMany(s => s.Products)
                .WithOne(p => p.Store)
                .HasForeignKey(p => p.StoreId)
                .OnDelete(DeleteBehavior.Cascade);
        }

        public DbSet<Store> Store { get; set; } 
        public DbSet<Product> Product { get; set; } 
    }
}
