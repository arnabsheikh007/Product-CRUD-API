global using Microsoft.EntityFrameworkCore;

namespace Product_CRUD_API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) :base(options) 
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ProductsDB;Trusted_Connection=true;TrustServerCertificate=true;");
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(x => x.TenantId);
            base.OnModelCreating(modelBuilder);
        }
    }
}
