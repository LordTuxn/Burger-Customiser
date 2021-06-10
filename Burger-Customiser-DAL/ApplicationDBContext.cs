using Burger_Customiser_BLL;
using Burger_Customiser_BLL.Relationships;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Windows;

namespace Burger_Customiser_DAL {

    public sealed class ApplicationDbContext : DbContext {
        private readonly IConfiguration _config;
        private readonly ILogger<ApplicationDbContext> _logger;

        public DbSet<Article> Article { get; set; }
        public DbSet<Ingredient> Ingredient { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }

        public DbSet<BurgerIngredient> BurgerIngredients { get; set; }

        public ApplicationDbContext(ILogger<ApplicationDbContext> logger, IConfiguration config) {
            this._config = config;
            this._logger = logger;

            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            do {
                try {
                    var connectionString =
                        $@"server={_config["Data:Server"]}; " +
                        $@"port={_config["Data:Port"]}; " +
                        $@"database={_config["Data:Database"]}; " +
                        $@"user={_config["Data:Username"]}; " +
                        $@"password={_config["Data:Password"]}; " +
                        "Persist Security Info=False; Connect Timeout=300;";

                    optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

                    _logger.LogInformation("Successfully connected to database!");
                    break;
                } catch (MySqlConnector.MySqlException) {
                    var result = MessageBox.Show("Could not connect to database!\n\nDo you want to retry?", "No Connection", MessageBoxButton.YesNo, MessageBoxImage.Error);

                    if (MessageBoxResult.No == result) Process.GetCurrentProcess().Kill(); // Application.Current.Shutdown(); doesn't work for some reason...
                }
            } while (true); 
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