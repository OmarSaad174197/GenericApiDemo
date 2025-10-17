using GenericDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace GenericDemo.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Product>()
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Entity<Customer>()
            .Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(100);
                
        }

    }
}
