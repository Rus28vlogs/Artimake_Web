using Microsoft.EntityFrameworkCore;
using Artimake_Web.Models;

namespace Artimake_Web.Data
{
    public class ArtimakeDbContext : DbContext
    {
        public ArtimakeDbContext(DbContextOptions<ArtimakeDbContext> options)
            : base(options)
        {
        }

        public DbSet<Craftsman> Craftsmen { get; set; }
        public DbSet<CraftsmanCategory> CraftsmanCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<ProductPhoto> ProductPhotos { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<DeliveryAddress> DeliveryAddresses { get; set; }
        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Здесь можно настроить сложные отношения, индексы, имена таблиц и т.д., если это необходимо
          
            modelBuilder.Entity<Product>()
                .HasOne<Craftsman>(p => p.Craftsman)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CraftsmanId)
                .OnDelete(DeleteBehavior.Cascade);

            // Или если вы хотите переопределить имена таблиц:
            modelBuilder.Entity<Craftsman>().ToTable("Craftsmen");
            modelBuilder.Entity<CraftsmanCategory>().ToTable("CraftsmenCategories");
           

            base.OnModelCreating(modelBuilder);
        }
    }
}
