using Burger_Customiser_BLL;
using Burger_Customiser_BLL.Relationships;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Burger_Customiser_DAL {

    public class ApplicationDBContext : DbContext {
        private readonly IConfiguration config;
        private ILogger<ApplicationDBContext> logger;

        public DbSet<Article> Article { get; set; }
        public DbSet<Ingredient> Ingredient { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }

        public DbSet<BurgerIngredient> BurgerIngredients { get; set; }

        public ApplicationDBContext(ILogger<ApplicationDBContext> loggger, IConfiguration config) {
            this.config = config;

            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            try {
                string connectionString =
                        $@"server={config["Data:Server"]}; " +
                        $@"port={config["Data:Port"]}; " +
                        $@"database={config["Data:Database"]}; " +
                        $@"user={config["Data:Username"]}; " +
                        $@"password={config["Data:Password"]}; " +
                        "Persist Security Info=False; Connect Timeout=300;";

                optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

                logger.LogInformation("Successfully connected to database!");
            } catch {
                // TODO: Send information and close window
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Article>()
                .HasDiscriminator<string>("Type")
                .HasValue<Article>("Article")
                .HasValue<Ingredient>("Ingredient")
                .HasValue<Product>("Product");

            // Add relation between Ingredient and Burger
            modelBuilder.Entity<BurgerIngredient>()
                .HasOne(b => b.Burger)
                .WithMany(b => b.BurgerIngredients)
                .HasForeignKey(b => b.BurgerID);

            modelBuilder.Entity<BurgerIngredient>()
                .HasOne(i => i.Ingredient)
                .WithMany(i => i.BurgerIngredients)
                .HasForeignKey(i => i.IngredientID);

            // Add relation between Order and Product
            modelBuilder.Entity<OrderProduct>()
                .HasOne(o => o.Order)
                .WithMany(o => o.ProductOrders)
                .HasForeignKey(o => o.OrderID);

            modelBuilder.Entity<OrderProduct>()
                .HasOne(p => p.Product)
                .WithMany(p => p.ProductOrders)
                .HasForeignKey(p => p.ProductID);

            // Add relation between Order and Burger
            modelBuilder.Entity<OrderBurger>()
                .HasOne(o => o.Order)
                .WithMany(o => o.BurgerOrders)
                .HasForeignKey(o => o.OrderID);

            modelBuilder.Entity<OrderBurger>()
                .HasOne(b => b.Burger)
                .WithMany(b => b.BurgerOrders)
                .HasForeignKey(b => b.BurgerID);
        }
    }
}