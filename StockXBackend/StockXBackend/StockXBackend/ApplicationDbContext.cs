using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore;

namespace StockXBackend
{ 
        public class ApplicationDbContext : DbContext
        {
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

            public DbSet<User> Users { get; set; }
            public DbSet<Product> Products { get; set; }
            public DbSet<Order> Orders { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<User>().HasKey(u => u.Id);
                modelBuilder.Entity<Product>().HasKey(p => p.Id);
                modelBuilder.Entity<Order>().HasKey(o => o.Id);

                modelBuilder.Entity<Order>()
                    .HasOne(o => o.User)
                    .WithMany()
                    .HasForeignKey(o => o.UserId);

                modelBuilder.Entity<Order>()
                    .HasMany(o => o.Products)
                    .WithMany();
            }
        }
    }
}
