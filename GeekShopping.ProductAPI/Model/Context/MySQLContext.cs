using Microsoft.EntityFrameworkCore;

namespace GeekShopping.ProductAPI.Model.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext() { }
        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(new Product()
            {
                Id = 2,
                Name = "Camiseta",
                Price = new decimal(49.90),
                Description = "Uma linda camiseta da cor vermelha",
                ImageURL = "http://localhost:5000/camiseta",
                CategoryName = "Camiseta"
            });
            modelBuilder.Entity<Product>().HasData(new Product()
            {
                Id = 3,
                Name = "Bermuda",
                Price = new decimal(89.90),
                Description = "Uma linda bermuda da cor preta",
                ImageURL = "http://localhost:5000/camiseta",
                CategoryName = "Bermuda"
            });
        }
    }
}
