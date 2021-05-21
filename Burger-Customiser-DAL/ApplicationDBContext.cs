using Burger_Customiser_BLL;
using Microsoft.EntityFrameworkCore;

namespace Burger_Customiser_DAL {
    public class ApplicationDBContext : DbContext {

        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) {
            Database.EnsureCreated();
        }
    }
}
