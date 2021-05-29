using Burger_Customiser_BLL;
using Burger_Customiser_BLL.Relationships;
using Microsoft.EntityFrameworkCore;

namespace Burger_Customiser_DAL {
    public class ApplicationDBContext : DbContext {

        public DbSet<Product> Product { get; set; }
        public DbSet<Ingredient> Ingredient { get; set; }
        public DbSet<Category> Category { get; set; }

        public DbSet<BurgerIngredient> BurgerIngredients { get; set; }

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            // Add relation between Ingredient and Burger
            modelBuilder.Entity<BurgerIngredient>()
                .HasOne(b => b.Burger)
                .WithMany(b => b.BurgerIngredients)
                .HasForeignKey(b => b.BurgerID);

            modelBuilder.Entity<BurgerIngredient>()
                .HasOne(i => i.Ingredient)
                .WithMany(i => i.BurgerIngredient)
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

            base.OnModelCreating(modelBuilder);
        }
    }
}
