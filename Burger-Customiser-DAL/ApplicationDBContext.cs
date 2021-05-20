using Burger_Customiser_BLL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Burger_Customiser_DAL {
    public class ApplicationDBContext : DbContext {

        public DbSet<Article> Article { get; set; }

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) {}
    }
}
