using Burger_Customiser_BLL;
using Burger_Customiser_BLL.Relationships;
using Microsoft.EntityFrameworkCore;

namespace Burger_Customiser_DAL {
    public class ApplicationDBContext : DbContext {

        public DbSet<Product> Product { get; set; }
        public DbSet<Ingredient> Ingredient { get; set; }
        public DbSet<Category> Category { get; set; }

        public DbSet<BurgerHasIngredients> BurgerIngredients { get; set; }

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            // Add relation between Ingredient and Burger
            modelBuilder.Entity<BurgerHasIngredients>()
                .HasOne(b => b.Burger)
                .WithMany(b => b.BurgerIngredients)
                .HasForeignKey(b => b.BurgerID);

            modelBuilder.Entity<BurgerHasIngredients>()
                .HasOne(i => i.Ingredient)
                .WithMany(i => i.BurgerIngredient)
                .HasForeignKey(i => i.IngredientID);

            base.OnModelCreating(modelBuilder);
        }
    }
}
